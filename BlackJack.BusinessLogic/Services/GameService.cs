using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Helpers.Interfaces;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.GameViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : BaseService, IGameService
    {
        private readonly IRanksHelper _ranksHelper;
        private readonly Random _random = new Random();
        private const int Draw = 21;
        private const int MidleDraw = 20;

        public GameService(IBaseUnitOfWork unitOfWork, IRanksHelper ranksHelper)
            : base(unitOfWork)
        {
            _ranksHelper = ranksHelper;
        }

        public async Task<GetAllStepsByPlayerIdAndGameIdGameView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameID)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var model = new GetAllStepsByPlayerIdAndGameIdGameView();
            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var playerSteps = await _database.PlayerSteps.GetAllByPlayerIdAndGameId(playerId, gameID);

            model.PlayerSteps = playerSteps.Select(step => new PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem()
            {
                Id = step.Id,
                Player = new PlayerGetAllStepsByPlayerIdAndGameIdGameView()
                {
                    PlayerId = step.PlayerId,
                    Balance = step.Player.Balance,
                    UserName = step.Player.UserName,
                    Bet = step.Player.Bet
                },
                Game = new GameGetAllStepsByPlayerIdAndGameIdGameView()
                {
                    GameId = step.GameId,
                    GameState = (GameStateTypeEnumView)step.Game.GameState
                },
                Rank = (RankTypeEnumView)step.Rank,
                Suite = (SuiteTypeEnumView)step.Suite
            }).ToList();

            return model;
        }

        public async Task<GetAllStepOfBotsByGameIdGameView> GetAllStepOfBotsByGameId(Guid gameId)
        {
            var model = new GetAllStepOfBotsByGameIdGameView();
            var botSteps = await _database.BotSteps.GetAllByGameId(gameId);

            model.BotSteps = botSteps.Select(x => new BotStepGetAllStepOfBotsByGameIdGameViewItem()
            {
                Id = x.Id,
                Rank = (RankTypeEnumView)x.Rank,
                Suite = (SuiteTypeEnumView)x.Suite,
                Bot = new BotGetAllStepOfBotsByGameIdGameView()
                {
                    Id = x.BotId,
                    Name = x.Bot.Name,
                    Balance = x.Bot.Balance,
                    Bet = x.Bot.Bet
                }
            }).OrderBy(b => b.Bot.Name)
            .ToList();

            return model;
        }

        public async Task<GetAllBotsByGameIdGameView> GetAllBotsByGameId(Guid gameId)
        {
            var model = new GetAllBotsByGameIdGameView();
            var bots = await _database.BotSteps.GetAllBotsByGameId(gameId);

            model.Bots = bots.Select(bot => new BotGetAllBotsByGameIdGameViewItem()
            {
                Id = bot.Id,
                Name = bot.Name,
                Balance = bot.Balance,
                Bet = bot.Bet
            }).ToList();

            return model;
        }

        public async Task<StartGameView> Start(string playerName, int countOfBots)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new CustomServiceException("Player name cannot be null");
            }

            var player = await _database.Players.GetByName(playerName);
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var isActiveGame = await _database.Games.GetActiveByPlayerId(player.Id);
            var game = new Game();
            if (isActiveGame != null)
            {
                game = isActiveGame;
            }
            else
            {
                game = new Game()
                {
                    PlayerId = player.Id,
                    Player = player,
                    GameState = (GameStateType)GameStateTypeEnumView.Unknown
                };

                await _database.Games.Create(game);

                var playerSteps = new List<PlayerStep>
                {
                    CreatePlayerStep(player, game),
                    CreatePlayerStep(player, game)
                };
                await _database.PlayerSteps.AddRange(playerSteps);
            }

            var bots = new List<Bot>();
            bots = (isActiveGame != null) ?
                await _database.BotSteps.GetAllBotsByGameId(isActiveGame.Id) :
                    await _database.BotSteps.GetAllBotsByGameId(game.Id);

            if (bots == null || bots.Count == 0)
            {
                var stepsOfAllBots = new List<BotStep>();
                var countOfAlreadyExistBots = await _database.Bots.Count() + 1;
                var createdBots = new List<Bot>();
                if (countOfBots > 0)
                {
                    for (int i = 0; i < countOfBots; i++)
                    {
                        var bot = new Bot()
                        {
                            Balance = 1000,
                            Bet = 0,
                            Name = $"Bot {countOfAlreadyExistBots}"
                        };
                        createdBots.Add(bot);

                        countOfAlreadyExistBots += 1;
                        stepsOfAllBots.Add(CreateBotStep(bot, game));
                        stepsOfAllBots.Add(CreateBotStep(bot, game));
                    }
                }
                await _database.Bots.Create(createdBots);
                await _database.BotSteps.AddRange(stepsOfAllBots);
            }

            await _database.Players.Update(player);
            var result = new StartGameView()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                CountOfBots = countOfBots,
                Player = new PlayerStartGameView()
                {
                    PlayerId = game.Player.Id,
                    UserName = game.Player.UserName,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            };
            return result;
        }

        public async Task<GetDetailsByPlayerIdAndGameIdGameView> GetDetailsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player is unautorized");
            }

            var game = await GetGameDetailsByPlayerIdAndGameId(playerId, gameId);
            var playerSteps = await GetAllStepsByPlayerIdAndGameId(playerId, game.Id);
            var botsSteps = await GetAllStepOfBotsByGameId(game.Id);
            var model = new GetDetailsByPlayerIdAndGameIdGameView()
            {
                Game = new StartGameView()
                {
                    Id = game.Id,
                    WonName = game.WonName,
                    Player = new PlayerStartGameView()
                    {
                        PlayerId = game.Player.PlayerId,
                        UserName = game.Player.UserName,
                        Balance = game.Player.Balance,
                        Bet = game.Player.Bet
                    },
                    GameState = game.GameState,
                    CountOfBots = game.CountOfBots
                },
                PlayerSteps = playerSteps,
                BotsSteps = botsSteps
            };
            return model;
        }

        public async Task<GetGameDetailsByPlayerIdAndGameIdGameView> GetGameDetailsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player is unautorized");
            }

            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var activeGame = await _database.Games.GetActiveByPlayerId(playerId);
            var lastActiveGame = await _database.Games.Get(gameId);
            if (activeGame == null && lastActiveGame == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var game = activeGame;
            if (activeGame == null)
                game = lastActiveGame;

            var result = new GetGameDetailsByPlayerIdAndGameIdGameView()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                WonName = game.WonName,
                Player = new PlayerGameDetailsByPlayerIdAndGameIdGameView()
                {
                    PlayerId = player.Id,
                    UserName = player.UserName,
                    Balance = player.Balance,
                    Bet = player.Bet
                }
            };
            return result;
        }

        private PlayerStep CreatePlayerStep(Player player, Game game)
        {
            var result = new PlayerStep()
            {
                PlayerId = player.Id,
                Player = player,
                Rank = (RankType)_random.Next(1, 13),
                Suite = (SuiteType)_random.Next(1, 4),
                Game = game,
                GameId = game.Id
            };
            return result;
        }

        private BotStep CreateBotStep(Bot bot, Game game)
        {
            var result = new BotStep()
            {
                Bot = bot,
                BotId = bot.Id,
                GameId = game.Id,
                Game = game,
                Rank = (RankType)_random.Next(1, 13),
                Suite = (SuiteType)_random.Next(1, 4)
            };
            return result;
        }

        public async Task<HitGameView> Hit(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await _database.Games.GetActiveByPlayerId(playerId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var playerStep = new PlayerStep()
            {
                Player = player,
                PlayerId = player.Id,
                Rank = (RankType)_random.Next(1, 13),
                Suite = (SuiteType)_random.Next(1, 4),
                Game = game,
                GameId = game.Id
            };
            await _database.PlayerSteps.Create(playerStep);

            var playerSteps = await _database.PlayerSteps.GetAllByPlayerIdAndGameId(playerId, game.Id);

            var ranks = new List<RankType>();

            ranks = playerSteps.Select(step => step.Rank).ToList();

            var totalValueOfPlayerCards = _ranksHelper.TotalValue(ranks);
            if (totalValueOfPlayerCards > Draw)
            {
                player.Balance -= player.Bet;
                var bots = await _database.BotSteps.GetAllBotsByGameId(game.Id);
                var wonName = await CheckingCardsOfBots(bots, game);
                game.WonName = wonName;
                game.GameState = GameStateType.BotWon;
            }
            await _database.Games.Update(game);
            await _database.Players.Update(player);

            var result = new HitGameView()
            {
                PlayerId = playerStep.PlayerId,
                GameId = playerStep.GameId,
                Rank = (RankTypeEnumView)playerStep.Rank,
                Suite = (SuiteTypeEnumView)playerStep.Suite
            };

            return result;
        }

        public async Task PlaceABet(string playerId, decimal bet)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            if (player.Balance < bet)
            {
                throw new CustomServiceException("There is not enough means on the account");
            }

            player.Bet = bet;
            player.Balance -= bet;
            await _database.Players.Update(player);
        }

        public async Task Stand(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await _database.Games.GetActiveByPlayerId(playerId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var bots = await _database.BotSteps.GetAllBotsByGameId(game.Id);

            if (game.GameState != GameStateType.Unknown)
            {
                return;
            }

            var allBotSteps = await _database.BotSteps.GetAll();

            var playerSteps = await _database.PlayerSteps.GetAllByPlayerIdAndGameId(playerId, game.Id);

            foreach (var bot in bots)
            {
                var botSteps = allBotSteps.Select(step => step)
                    .Where(step => step.BotId == bot.Id)
                    .ToList();

                var playerRanks = new List<RankType>();

                playerRanks = playerSteps.Select(step => step.Rank).ToList();

                var botRanks = new List<RankType>();

                botRanks = botSteps.Select(step => step.Rank).ToList();

                var createdBotSteps = new List<BotStep>();
                var totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                while (totalValueOfBotCards <= MidleDraw)
                {
                    var botStep = new BotStep()
                    {
                        Game = game,
                        GameId = game.Id,
                        Bot = bot,
                        BotId = bot.Id,
                        Rank = (RankType)_random.Next(1, 13),
                        Suite = (SuiteType)_random.Next(1, 4)
                    };
                    botRanks.Add(botStep.Rank);
                    createdBotSteps.Add(botStep);
                    totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                }
                await _database.BotSteps.Create(createdBotSteps);

                var isTotalValuePlayerMoreThanBot = _ranksHelper.TotalValue(playerRanks) > _ranksHelper.TotalValue(botRanks);
                totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                var totalValueOfPlayerCards = _ranksHelper.TotalValue(playerRanks);

                if (totalValueOfBotCards > Draw || isTotalValuePlayerMoreThanBot)
                {
                    player.Balance += player.Bet;
                    game.WonName = player.UserName;
                    game.GameState = GameStateType.PlayerWon;
                }
                else if (totalValueOfBotCards == totalValueOfPlayerCards)
                {
                    game.GameState = GameStateType.Draw;
                    game.WonName = player.UserName;
                }
                else
                {
                    player.Balance -= player.Bet;
                    game.WonName = player.UserName;
                    game.GameState = GameStateType.BotWon;
                }
            }

            await _database.Games.Update(game);
            await _database.Players.Update(player);

            await _database.Bots.Update(bots);
        }

        private async Task<string> CheckingCardsOfBots(IEnumerable<Bot> bots, Game game)
        {
            var amountsCardsOfAllBots = new Dictionary<string, int>();
            string nameOfWonBot = "";

            var allSteps = await _database.BotSteps.GetAll();
            var createdSteps = new List<BotStep>();

            foreach (var bot in bots)
            {
                var botSteps = allSteps.Select(step => step)
                    .Where(step => step.BotId == bot.Id)
                    .ToList();

                var botRanks = new List<RankType>();
                botRanks = botSteps.Select(step => step.Rank).ToList();

                var totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                while (totalValueOfBotCards <= MidleDraw)
                {
                    var botStep = new BotStep()
                    {
                        Game = game,
                        GameId = game.Id,
                        Bot = bot,
                        BotId = bot.Id,
                        Rank = (RankType)_random.Next(1, 13),
                        Suite = (SuiteType)_random.Next(1, 4)
                    };
                    botRanks.Add(botStep.Rank);
                    createdSteps.Add(botStep);
                    totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                }

                totalValueOfBotCards = _ranksHelper.TotalValue(botRanks);
                amountsCardsOfAllBots.Add(bot.Name, totalValueOfBotCards);
            }
            await _database.BotSteps.Create(createdSteps);

            var maxAmount = 0;

            foreach (var item in amountsCardsOfAllBots)
            {
                if (item.Value == Draw)
                {
                    nameOfWonBot = item.Key;
                }
                else if (item.Value < Draw)
                {
                    if (item.Value > maxAmount)
                    {
                        maxAmount = item.Value;
                        nameOfWonBot = item.Key;
                    }
                }
            }

            return (nameOfWonBot == "") ? nameOfWonBot = "NOBODY" : nameOfWonBot;
        }

        public async Task<GetAllByPlayerIdGameView> GetAllByPlayerId(string playerId)
        {
            var result = new GetAllByPlayerIdGameView();
            var games = await _database.Games.GetAllByPlayerId(playerId);

            result.Games = games.Select(game => new GameGetAllByPlayerIdGameViewItem()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                Player = new PlayerGetAllByPlayerIdGameView()
                {
                    PlayerId = game.Player.Id,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            }).ToList();

            return result;
        }

        public async Task<GetByIdGameView> GetById(Guid gameId)
        {
            var game = await _database.Games.Get(gameId);

            var result = (game == null) ?
                throw new CustomServiceException("Game does not exist") :
                new GetByIdGameView()
                {
                    Id = game.Id,
                    Player = new PlayerGetByIdGameView()
                    {
                        PlayerId = game.Player.Id,
                        Balance = game.Player.Balance,
                        Bet = game.Player.Bet
                    },
                    GameState = (GameStateTypeEnumView)game.GameState
                };

            return result;
        }
    }
}
