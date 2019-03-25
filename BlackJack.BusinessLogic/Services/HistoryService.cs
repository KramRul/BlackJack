using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.HistoryViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService : BaseService, IHistoryService
    {
        private const int CountOfSteps = 5;
        public HistoryService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GetDetailsByGameIdHistoryView> GetDetailsByGameId(string gameId)
        {
            var validGameId = Guid.Empty;
            var isValidGameId = Guid.TryParse(gameId, out validGameId);
            if (!isValidGameId)
            {
                throw new CustomServiceException("Game Id is not valid");
            }

            var game = await _database.Games.Get(validGameId);
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var result = new GetDetailsByGameIdHistoryView()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                WonName = game.WonName,
                Player = new PlayerGetDetailsByGameIdHistoryView()
                {
                    Id = game.PlayerId,
                    UserName = game.Player.UserName,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            };
            return result;
        }

        public async Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames()
        {
            var result = new GetHistoryOfGamesHistoryView();
            var games = await _database.Games.GetAll();

            result.Games = games.Select(game => new GameGetHistoryOfGamesHistoryViewItem()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                Player = new PlayerGetHistoryOfGamesHistoryView()
                {
                    PlayerId = game.PlayerId,
                    UserName = game.Player.UserName,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            }).ToList();

            return result;
        }

        private async Task<GetAllStepsByPlayerIdAndGameIdHistoryView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var model = new GetAllStepsByPlayerIdAndGameIdHistoryView();

            var validPlayerId = Guid.Empty;
            var isValidPlayerId = Guid.TryParse(playerId, out validPlayerId);
            if (!isValidPlayerId)
            {
                throw new CustomServiceException("Player Id is not valid");
            }

            var player = await _database.Players.Get(validPlayerId);
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var playerSteps = await _database.PlayerSteps.GetAllByPlayerIdAndGameId(playerId, gameId);

            model.PlayerSteps = playerSteps.Select(step => new PlayerStepGetAllStepsByPlayerIdAndGameIdHistoryViewItem()
            {
                Id = step.Id,
                Player = new PlayerGetAllStepsByPlayerIdAndGameIdHistoryView()
                {
                    PlayerId = step.PlayerId,
                    Balance = step.Player.Balance,
                    UserName = step.Player.UserName,
                    Bet = step.Player.Bet
                },
                Game = new GameGetAllStepsByPlayerIdAndGameIdHistoryView()
                {
                    GameId = step.GameId,
                    GameState = (GameStateTypeEnumView)step.Game.GameState
                },
                Rank = (RankTypeEnumView)step.Rank,
                Suite = (SuiteTypeEnumView)step.Suite
            }).ToList();

            return model;
        }

        private async Task<GetAllStepOfBotsByGameIdHistoryView> GetAllStepOfBotsByGameId(Guid gameId)
        {
            var model = new GetAllStepOfBotsByGameIdHistoryView();
            var botSteps = await _database.BotSteps.GetAllByGameId(gameId);

            model.BotSteps = botSteps.Select(x => new BotStepGetAllStepOfBotsByGameIdHistoryViewItem()
            {
                Id = x.Id,
                Rank = (RankTypeEnumView)x.Rank,
                Suite = (SuiteTypeEnumView)x.Suite,
                Bot = new BotGetAllStepOfBotsByGameIdHistoryView()
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

        private async Task<GetAllBotsByGameIdHistoryView> GetAllBotsByGameId(Guid gameId)
        {
            var model = new GetAllBotsByGameIdHistoryView();
            var bots = await _database.Bots.GetAllBotsByGameId(gameId);

            model.Bots = bots.Select(bot => new BotGetAllBotsByGameIdHistoryViewItem()
            {
                Id = bot.Id,
                Name = bot.Name,
                Balance = bot.Balance,
                Bet = bot.Bet
            }).ToList();

            return model;
        }

        public async Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GetStepsDetailsOfGameHistoryView model)
        {
            var playerSteps = await GetAllStepsByPlayerIdAndGameId(model.Game.Player.Id, model.Game.Id);
            var botsSteps = await GetAllStepOfBotsByGameId(model.Game.Id);

            var steps = new List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
            var cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryViewItem>();

            for (int i = 0; i < CountOfSteps; i++)
            {
                cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryViewItem>();

                if (playerSteps.PlayerSteps.Count >= i)
                {
                    var playerCard = playerSteps.PlayerSteps.Select(step => new CardPlayerAndBotStepsDetailsOfGameHistoryViewItem()
                    {
                        Id = step.Id,
                        Suite = step.Suite,
                        Rank = step.Rank,
                        Player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = step.Player.PlayerId,
                            UserName = step.Player.UserName,
                            Balance = step.Player.Balance,
                            Bet = step.Player.Bet
                        },
                        Game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = model.Game.Id,
                            WonName = model.Game.WonName,
                            GameState = model.Game.GameState
                        },
                        Bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = Guid.NewGuid(),
                            Name = "",
                            Balance = 0,
                            Bet = 0
                        }
                    }).FirstOrDefault();
                    cards.Add(playerCard);
                    playerSteps.PlayerSteps.RemoveAt(0);
                }
                foreach (var bot in model.Bots.Bots)
                {
                    var botStep = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).FirstOrDefault();
                    if (botStep != null)
                    {
                        var botCard = botsSteps.BotSteps.Select(step => new CardPlayerAndBotStepsDetailsOfGameHistoryViewItem()
                        {
                            Id = step.Id,
                            Suite = step.Suite,
                            Rank = step.Rank,
                            Player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = "",
                                UserName = "",
                                Balance = 0,
                                Bet = 0
                            },
                            Game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = model.Game.Id,
                                WonName = model.Game.WonName,
                                GameState = model.Game.GameState
                            },
                            Bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = step.Bot.Id,
                                Name = step.Bot.Name,
                                Balance = step.Bot.Balance,
                                Bet = step.Bot.Bet
                            }
                        }).Where(b => b.Bot.Id == bot.Id).FirstOrDefault();
                        cards.Add(botCard);
                        botStep = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).FirstOrDefault();
                        botsSteps.BotSteps.Remove(botStep);
                    }
                }

                if (cards.Count != 0)
                {
                    steps.Add(new StepPlayerAndBotStepsDetailsOfGameHistoryViewItem()
                    {
                        Cards = cards
                    });
                }
            }

            return steps;
        }

        public async Task<DetailsOfGameHistoryView> DetailsOfGame(GetDetailsByGameIdHistoryView game)
        {
            var bots = await GetAllBotsByGameId(game.Id);

            var gameDetails = new GameGetStepsDetailsOfGameHistoryView()
            {
                Id = game.Id,
                GameState = game.GameState,
                WonName = game.WonName,
                Player = new PlayerGetStepsDetailsOfGameHistoryView()
                {
                    Id = game.Player.Id,
                    UserName = game.Player.UserName,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            };

            var botsDetails = new BotsGetStepsDetailsOfGameHistoryView
            {
                Bots = bots.Bots.Select(bot => new BotBotsGetStepsDetailsOfGameHistoryViewItem()
                {
                    Id = bot.Id,
                    Name = bot.Name,
                    Balance = bot.Balance,
                    Bet = bot.Bet
                }).ToList()
            };

            var steps = await GetStepsDetailsOfGame(new GetStepsDetailsOfGameHistoryView()
            {
                Game = gameDetails,
                Bots = botsDetails
            });

            var model = new DetailsOfGameHistoryView()
            {
                Game = new GameDetailsOfGameHistoryView()
                {
                    Id = game.Id,
                    WonName = game.WonName,
                    GameState = game.GameState,
                    Player = new PlayerDetailsOfGameHistoryView()
                    {
                        Id = game.Player.Id,
                        UserName = game.Player.UserName,
                        Balance = game.Player.Balance,
                        Bet = game.Player.Bet
                    }
                },
                PlayerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView()
                {
                    Steps = steps
                }
            };
            return model;
        }
    }
}
