using BlackJack.BusinessLogic.Common.Exceptions;
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

        public GameService(IUnitOfWork unitOfWork, IRanksHelper ranksHelper)
            : base(unitOfWork)
        {
            _ranksHelper = ranksHelper;
        }

        public async Task<GetAllStepsGameView> GetAllSteps(string playerId, Guid gameID)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var model = new GetAllStepsGameView();
            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var playerSteps = await Database.PlayerSteps.GetAllStepsByPlayerIdAndGameId(playerId, gameID);

            model.PlayerSteps = playerSteps.Select(step => new PlayerStepGetAllStepsGameViewItem()
            {
                Id = step.Id,
                Player = new PlayerGetAllStepsGameView()
                {
                    PlayerId = step.PlayerId,
                    Balance = step.Player.Balance,
                    UserName = step.Player.UserName,
                    Bet = step.Player.Bet
                },
                Game = new GameGetAllStepsGameView()
                {
                    GameId = step.GameId,
                    GameState = (GameStateTypeEnumView)step.Game.GameState
                },
                Rank = (RankTypeEnumView)step.Rank,
                Suite = (SuiteTypeEnumView)step.Suite
            }).ToList();

            return model;
        }

        public async Task<GetAllStepOfBotsGameView> GetAllStepOfBots(Guid gameId)
        {
            var model = new GetAllStepOfBotsGameView();
            var botSteps = await Database.BotSteps.GetAllStepsByGameId(gameId);

            model.BotSteps = botSteps.Select(x => new BotStepGetAllStepOfBotsViewItem()
            {
                Id = x.Id,
                Rank = (RankTypeEnumView)x.Rank,
                Suite = (SuiteTypeEnumView)x.Suite,
                Bot = new BotGetAllStepOfBotsView()
                {
                    Id = x.BotId,
                    Name = x.Bot.Name,
                    Balance = x.Bot.Balance,
                    Bet = x.Bot.Bet
                }
            }).ToList();

            return model;
        }

        public async Task<GetAllBotsInGameGameView> GetAllBotsInGame(Guid gameId)
        {
            var model = new GetAllBotsInGameGameView();
            var bots = await Database.BotSteps.GetAllBotsByGameId(gameId);

            model.Bots = bots.Select(bot => new BotGetAllBotsInGameGameViewItem()
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

            var player = await Database.Players.GetByName(playerName);
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var gameCheck = await Database.Games.GetActiveGameForPlayer(player.Id);
            var game = new Game();
            if (gameCheck != null)
            {
                //throw new CustomServiceException("There is active game");
                game = gameCheck;
            }
            else
            {
                game = new Game()
                {
                    Id = Guid.NewGuid(),
                    PlayerId = player.Id,
                    Player = player,
                    GameState = (GameState)GameStateTypeEnumView.Unknown
                };

                await Database.Games.Create(game);

                var playerSteps = new List<PlayerStep>
                {
                    CreatePlayerStep(player, game),
                    CreatePlayerStep(player, game)
                };
                await Database.PlayerSteps.AddRange(playerSteps);
            }

            var botCheck = new List<Bot>();
            if (gameCheck != null)
                botCheck = await Database.BotSteps.GetAllBotsByGameId(gameCheck.Id);
            else
                botCheck = await Database.BotSteps.GetAllBotsByGameId(game.Id);

            if (botCheck == null || botCheck.Count == 0)
            {
                var StepsOfAllBots = new List<BotStep>();
                var countOfBotsInDB = await Database.Bots.Count() + 1;
                if (countOfBots > 0)
                {
                    for (int i = 0; i < countOfBots; i++)
                    {
                        var bot = new Bot()
                        {
                            Id = Guid.NewGuid(),
                            Balance = 1000,
                            Bet = 0,
                            Name = String.Format("Bot {0}", countOfBotsInDB.ToString())
                        };
                        await Database.Bots.Create(bot);
                        countOfBotsInDB += 1;
                        StepsOfAllBots.Add(CreateBotStep(bot, game));
                        StepsOfAllBots.Add(CreateBotStep(bot, game));
                    }
                }
                await Database.BotSteps.AddRange(StepsOfAllBots);
            }

            //await Database.Games.Create(game);
            await Database.Players.Update(player);
            await Database.Save();
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

        public async Task<GetDetailsGameView> GetDetails(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player is unautorized");
            }

            var game = await GetGameDetails(playerId);
            var playerSteps = await GetAllSteps(playerId, game.Id);
            var botsSteps = await GetAllStepOfBots(game.Id);
            var model = new GetDetailsGameView()
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

        public async Task<GetDetailsResponseGameView> GetGameDetails(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player is unautorized");
            }

            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await Database.Games.GetActiveGameForPlayer(playerId);
            if (game == null)
            {
                game = await Database.Games.GetLastActiveGameForPlayer(playerId);
                if (game == null)
                {
                    throw new CustomServiceException("Game does not exist");
                }
            }

            var result = new GetDetailsResponseGameView()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                WonName = game.WonName,
                Player = new PlayerGetDetailsGameView()
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
            var random = new Random();
            var result = new PlayerStep()
            {
                Id = Guid.NewGuid(),
                PlayerId = player.Id,
                Player = player,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4),
                Game = game,
                GameId = game.Id
            };
            return result;
        }

        private BotStep CreateBotStep(Bot bot, Game game)
        {
            var random = new Random();
            var result = new BotStep()
            {
                Id = Guid.NewGuid(),
                Bot = bot,
                BotId = bot.Id,
                GameId = game.Id,
                Game = game,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4)
            };
            return result;
        }

        public async Task<HitGameView> Hit(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await Database.Games.GetActiveGameForPlayer(playerId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var random = new Random();
            var playerStep = new PlayerStep()
            {
                Id = Guid.NewGuid(),
                Player = player,
                PlayerId = player.Id,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4),
                Game = game,
                GameId = game.Id
            };
            await Database.PlayerSteps.Create(playerStep);
            await Database.Save();

            var playerSteps = await Database.PlayerSteps.GetAllStepsByPlayerIdAndGameId(playerId, game.Id);

            var ranks = new List<Rank>();
            foreach (var step in playerSteps)
            {
                ranks.Add(step.Rank);
            }

            if (_ranksHelper.TotalValue(ranks) > 21)
            {
                player.Balance -= player.Bet;
                var bots = await Database.BotSteps.GetAllBotsByGameId(game.Id);
                var wonName = await CheckingCardsOfBots(bots, game);
                game.WonName = wonName;
                game.GameState = GameState.BotWon;
            }
            await Database.Games.Update(game);
            await Database.Players.Update(player);
            await Database.Save();

            return new HitGameView()
            {
                PlayerId = playerStep.PlayerId,
                GameId = playerStep.GameId,
                Rank = (RankTypeEnumView)playerStep.Rank,
                Suite = (SuiteTypeEnumView)playerStep.Suite
            };
        }

        public async Task PlaceABet(string playerId, decimal bet)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            if (player.Balance < bet)
                throw new CustomServiceException("There is not enough means on the account");
            else
            {
                player.Bet = bet;
                player.Balance -= bet;
                await Database.Players.Update(player);
                await Database.Save();
            }
        }

        public async Task Stand(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await Database.Games.GetActiveGameForPlayer(playerId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var bots = await Database.BotSteps.GetAllBotsByGameId(game.Id);

            if (game.GameState != GameState.Unknown) return;

            foreach (var bot in bots)
            {
                var botSteps = await Database.BotSteps.GetAllStepsByBotId(bot.Id);

                var playerSteps = await Database.PlayerSteps.GetAllStepsByPlayerIdAndGameId(playerId, game.Id);

                var playerRanks = new List<Rank>();
                foreach (var step in playerSteps)
                {
                    playerRanks.Add(step.Rank);
                }

                var botRanks = new List<Rank>();
                foreach (var step in botSteps)
                {
                    botRanks.Add(step.Rank);
                }

                while (_ranksHelper.TotalValue(botRanks) <= 20)
                {
                    var rnd = new Random();
                    var botStep = new BotStep()
                    {
                        Id = Guid.NewGuid(),
                        Game = game,
                        GameId = game.Id,
                        Bot = bot,
                        BotId = bot.Id,
                        Rank = (Rank)rnd.Next(1, 13),
                        Suite = (Suite)rnd.Next(1, 4)
                    };
                    botRanks.Add(botStep.Rank);
                    await Database.BotSteps.Create(botStep);
                    await Database.Save();
                }
                if (_ranksHelper.TotalValue(botRanks) > 21 || _ranksHelper.TotalValue(playerRanks) > _ranksHelper.TotalValue(botRanks))
                {
                    player.Balance += player.Bet;
                    game.WonName = player.UserName;
                    game.GameState = GameState.PlayerWon;
                }
                else if (_ranksHelper.TotalValue(botRanks) == _ranksHelper.TotalValue(playerRanks))
                {
                    game.GameState = GameState.Draw;
                    game.WonName = player.UserName;
                }
                else
                {
                    player.Balance -= player.Bet;
                    game.WonName = player.UserName;
                    game.GameState = GameState.BotWon;
                }
            }

            await Database.Games.Update(game);
            await Database.Players.Update(player);

            foreach (var bot in bots)
            {
                await Database.Bots.Update(bot);
            }
            await Database.Save();
        }

        private async Task<string> CheckingCardsOfBots(IEnumerable<Bot> bots, Game game)
        {
            var amountOfCardsOfBots = new Dictionary<string, int>();
            string nameOfWonBot = "";

            foreach (var bot in bots)
            {
                var botSteps = await Database.BotSteps.GetAllStepsByBotId(bot.Id);

                var botRanks = new List<Rank>();
                foreach (var step in botSteps)
                {
                    botRanks.Add(step.Rank);
                }

                while (_ranksHelper.TotalValue(botRanks) <= 20)
                {
                    var rnd = new Random();
                    var botStep = new BotStep()
                    {
                        Id = Guid.NewGuid(),
                        Game = game,
                        GameId = game.Id,
                        Bot = bot,
                        BotId = bot.Id,
                        Rank = (Rank)rnd.Next(1, 13),
                        Suite = (Suite)rnd.Next(1, 4)
                    };
                    botRanks.Add(botStep.Rank);
                    await Database.BotSteps.Create(botStep);
                    await Database.Save();
                }

                amountOfCardsOfBots.Add(bot.Name.ToString(), _ranksHelper.TotalValue(botRanks));
            }

            var maxAmount = 0;

            foreach (var item in amountOfCardsOfBots)
            {
                if (item.Value == 21) nameOfWonBot = item.Key;
                else if (item.Value < 21)
                {
                    if (item.Value > maxAmount)
                    {
                        maxAmount = item.Value;
                        nameOfWonBot = item.Key;
                    }
                }
            }

            if (nameOfWonBot == "") nameOfWonBot = "NOBODY";

            return nameOfWonBot;
        }

        public async Task<GetGamesByPlayerIdGameView> GetGamesByPlayerId(string playerId)
        {
            var result = new GetGamesByPlayerIdGameView();
            var games = await Database.Games.GetGamesForPlayer(playerId);

            result.Games = games.Select(game => new GameGetGamesByPlayerIdGameViewItem()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                Player = new PlayerGetAllGamesByPlayerIdGameView()
                {
                    PlayerId = game.Player.Id,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            }).ToList();

            return result;
        }

        public async Task<GetGameView> Get(Guid gameId)
        {
            var game = await Database.Games.Get(gameId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            return new GetGameView()
            {
                Id = game.Id,
                Player = new PlayerGetGameView()
                {
                    PlayerId = game.Player.Id,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                },
                GameState = (GameStateTypeEnumView)game.GameState
            };
        }
    }
}
