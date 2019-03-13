using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.GameViews;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : BaseService, IGameService
    {
        private readonly IAdditionalRanksService _additionalRanksService;

        public GameService(IUnitOfWork unitOfWork, IAdditionalRanksService additionalRanksService)
            : base(unitOfWork)
        {
            _additionalRanksService = additionalRanksService;
        }

        public async Task<GetAllStepsGameView> GetAllSteps(string playerId, Guid gameID)
        {
            var model = new GetAllStepsGameView();
            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var playerSteps = await Database.PlayerSteps.GetAll();

            foreach (var item in playerSteps)
            {
                if (item.PlayerId == playerId && item.GameId == gameID)
                {
                    model.PlayerSteps.Add(new PlayerStepGetAllStepsGameViewItem()
                    {
                        Id = item.Id,
                        Player = new PlayerGetAllStepsGameView()
                        {
                            PlayerId = item.PlayerId,
                            Balance = item.Player.Balance,
                            UserName = item.Player.UserName,
                            Bet = item.Player.Bet
                        },
                        Game = new GameGetAllStepsGameView()
                        {
                            GameId = item.GameId,
                            GameState = (GameStateTypeEnumView)item.Game.GameState
                        },
                        Rank = (RankTypeEnumView)item.Rank,
                        Suite = (SuiteTypeEnumView)item.Suite
                    });
                }
            }
            return model;
        }

        public async Task<GetAllStepOfBotsGameView> GetAllStepOfBots(Guid gameId)
        {
            var model = new GetAllStepOfBotsGameView();
            var botSteps = await Database.BotSteps.GetAllStepsByGameId(gameId);
            foreach (var item in botSteps)
            {
                model.BotSteps.Add(new BotStepGetAllStepOfBotsViewItem()
                {
                    Id = item.Id,
                    Rank = (RankTypeEnumView)item.Rank,
                    Suite = (SuiteTypeEnumView)item.Suite,
                    Bot = new BotGetAllStepOfBotsView()
                    {
                        Id = item.BotId,
                        Name = item.Bot.Name,
                        Balance = item.Bot.Balance,
                        Bet = item.Bot.Bet
                    }
                });
            }
            return model;
        }

        public async Task<GetAllBotsInGameGameView> GetAllBotsInGame(Guid gameId)
        {
            var model = new GetAllBotsInGameGameView();
            var bots = await Database.BotSteps.GetAllBotsByGameId(gameId);
            foreach (var item in bots)
            {
                model.Bots.Add(new BotGetAllBotsInGameGameViewItem()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Balance = item.Balance,
                    Bet = item.Bet
                });
            }
            return model;
        }

        public async Task<StartGameView> Start(string playerName, int countOfBots)
        {
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

            var botCheck = await Database.BotSteps.GetAllBotsByGameId(gameCheck.Id);
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
            Database.Players.Update(player);
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

        public async Task<GetDetailsResponseGameView> GetDetails(string playerId)
        {
            if (playerId == null)
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

            if (_additionalRanksService.TotalValue(ranks) > 21)
            {
                player.Balance -= player.Bet;
                var bots = await Database.BotSteps.GetAllBotsByGameId(game.Id);
                var wonName = await CheckingCardsOfBots(bots, game);
                game.WonName = wonName;
                game.GameState = GameState.BotWon;
            }
            Database.Games.Update(game);
            Database.Players.Update(player);
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
                Database.Players.Update(player);
                await Database.Save();
            }
        }

        public async Task Stand(string playerId)
        {
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

                while (_additionalRanksService.TotalValue(botRanks) <= 20)
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
                if (_additionalRanksService.TotalValue(botRanks) > 21 || _additionalRanksService.TotalValue(playerRanks) > _additionalRanksService.TotalValue(botRanks))
                {
                    player.Balance += player.Bet;
                    game.WonName = player.UserName;
                    game.GameState = GameState.PlayerWon;
                }
                else if (_additionalRanksService.TotalValue(botRanks) == _additionalRanksService.TotalValue(playerRanks))
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

            Database.Games.Update(game);
            Database.Players.Update(player);

            foreach (var bot in bots)
            {
                Database.Bots.Update(bot);
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

                while (_additionalRanksService.TotalValue(botRanks) <= 20)
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

                amountOfCardsOfBots.Add(bot.Name.ToString(), _additionalRanksService.TotalValue(botRanks));
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

            foreach (var game in games)
            {
                if (game.Player.Id == playerId)
                {
                    result.Games.Add(new GameGetGamesByPlayerIdGameViewItem()
                    {
                        Id = game.Id,
                        GameState = (GameStateTypeEnumView)game.GameState,
                        Player = new PlayerGetAllGamesByPlayerIdGameView()
                        {
                            PlayerId = game.Player.Id,
                            Balance = game.Player.Balance,
                            Bet = game.Player.Bet
                        }
                    });
                }
            }
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
