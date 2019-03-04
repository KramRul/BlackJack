using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.PlayerViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
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
                            Bet = item.Player.Bet
                        },
                        Game = new GameGetAllStepsGameView()
                        {
                            GameId = item.GameId,
                            GameState = item.Game.GameState
                        },
                        Rank = item.Rank,
                        Suite = item.Suite
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
                    Rank = item.Rank,
                    Suite = item.Suite,
                    Bot = new BotGetAllStepOfBotsView()
                    {
                        Id=item.BotId,
                        Balance = item.Bot.Balance,
                        Bet = item.Bot.Bet
                    }
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
            if (gameCheck != null)
            {
                throw new CustomServiceException("There is active game");
            }

            var game = new Game()
            {
                
                Player = player,
                GameState = GameState.Unknown
            };

            var playerSteps = new List<PlayerStep>
            {
                CreatePlayerStep(player, game),
                CreatePlayerStep(player, game)
            };
            await Database.PlayerSteps.AddRange(playerSteps);

            var StepsOfAllBots = new List<BotStep>(); 
            if (countOfBots > 0)
            {
                for (int i = 0; i < countOfBots; i++)
                {
                    var bot = new Bot() { Balance = 1000, Bet = 0 };
                    StepsOfAllBots.Add(CreateBotStep(bot, game));
                    StepsOfAllBots.Add(CreateBotStep(bot, game));
                }
            }
            await Database.BotSteps.AddRange(StepsOfAllBots);

            await Database.Games.Create(game);
            Database.Players.Update(player);
            await Database.Save();
            var result = new StartGameView()
            {
                Id = game.Id,
                GameState = game.GameState,
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
                throw new CustomServiceException("Game does not exist");
            }

            var result = new GetDetailsResponseGameView()
            {
                Id = game.Id,
                GameState = game.GameState,
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
                Player = player,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4),
                Game = game
            };
            return result;
        }

        private BotStep CreateBotStep(Bot bot, Game game)
        {
            var random = new Random();
            var result = new BotStep()
            {
                Bot =bot,
                Game =game,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4)
            };
            return result;
        }

        public async Task<HitGameView> Hit(string playerId, string gameId)
        {
            var player = await Database.Players.Get(Guid.Parse(playerId));

            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await Database.Games.Get(Guid.Parse(gameId));

            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var random = new Random();
            var playerStep = new PlayerStep()
            {
                Player = player,
                Rank = (Rank)random.Next(1, 13),
                Suite = (Suite)random.Next(1, 4),
                Game = game
            };
            await Database.PlayerSteps.Create(playerStep);
            await Database.Save();

            var playerSteps = await Database.PlayerSteps.GetAllStepsByPlayerIdAndGameId(playerId, game.Id);

            var ranks = new List<Rank>();
            foreach (var step in playerSteps)
            {
                ranks.Add(step.Rank);
            }

            if (TotalValue(ranks) > 21)
            {
                player.Balance -= player.Bet;
                game.GameState = GameState.BotWon;
            }
            Database.Games.Update(game);
            Database.Players.Update(player);
            await Database.Save();

            return new HitGameView()
            {
                PlayerId = playerStep.PlayerId,
                GameId = playerStep.GameId,
                Rank = playerStep.Rank,
                Suite = playerStep.Suite
            };
        }

        private int TotalValue(IEnumerable<Rank> steps)
        {
            int totalSum = 0;
            foreach (var card in steps)
            {
                if (card == Rank.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                }
                else if (card == Rank.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card == Rank.Jack || card == Rank.King || card == Rank.Queen)
                {
                    totalSum += 10;
                }
                switch (card)
                {
                    case Rank.Two:
                        totalSum += 2;
                        break;
                    case Rank.Three:
                        totalSum += 3;
                        break;
                    case Rank.Four:
                        totalSum += 4;
                        break;
                    case Rank.Five:
                        totalSum += 5;
                        break;
                    case Rank.Six:
                        totalSum += 6;
                        break;
                    case Rank.Seven:
                        totalSum += 7;
                        break;
                    case Rank.Eight:
                        totalSum += 8;
                        break;
                    case Rank.Nine:
                        totalSum += 9;
                        break;
                    case Rank.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
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

        public async Task Stand(string playerId, Guid gameId)
        {
            var player = await Database.Players.Get(Guid.Parse(playerId));

            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var game = await Database.Games.Get(gameId);

            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var bots = await Database.BotSteps.GetAllBotsByGameId(game.Id);

            if (game.GameState != GameState.Unknown) return;

            foreach (var bot in bots)
            {
                var botSteps = await Database.BotSteps.GetAllStepsByBotId(bot.Id);

                var playerSteps = await Database.PlayerSteps.GetAllStepsByPlayerIdAndGameId(playerId, gameId);

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

                while (TotalValue(botRanks) <= 20)
                {
                    var rnd = new Random();
                    var botStep = new BotStep()
                    {
                        Game =game,
                        GameId =gameId,
                        Bot =bot, BotId=bot.Id,
                        Rank = (Rank)rnd.Next(1, 13),
                        Suite = (Suite)rnd.Next(1, 4)
                    };
                    botRanks.Add(botStep.Rank);
                    await Database.BotSteps.Create(botStep);
                    await Database.Save();
                }
                if (TotalValue(botRanks) > 21 || TotalValue(playerRanks) > TotalValue(botRanks))
                {
                    player.Balance += player.Bet;
                    game.GameState = GameState.PlayerWon;
                }
                else if (TotalValue(botRanks) == TotalValue(playerRanks))
                {
                    game.GameState = GameState.Draw;
                }
                else
                {
                    player.Balance -= player.Bet;
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
                        GameState = game.GameState,
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
                GameState = game.GameState
            };
        }
    }
}
