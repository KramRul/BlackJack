using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.GameViews;
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
            var validGameId = new Guid();
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

        public async Task<GetAllStepsByPlayerIdAndGameIdHistoryView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new CustomServiceException("Player cannot be null");
            }

            var model = new GetAllStepsByPlayerIdAndGameIdHistoryView();

            var validPlayerId = new Guid();
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

        public async Task<GetAllStepOfBotsByGameIdHistoryView> GetAllStepOfBotsByGameId(Guid gameId)
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

        public async Task<GetAllBotsByGameIdHistoryView> GetAllBotsByGameId(Guid gameId)
        {
            var model = new GetAllBotsByGameIdHistoryView();
            var bots = await _database.BotSteps.GetAllBotsByGameId(gameId);

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
            GameGetStepsDetailsOfGameHistoryView game,
            BotsGetStepsDetailsOfGameHistoryView bots
            )
        {
            var playerSteps = await GetAllStepsByPlayerIdAndGameId(game.Player.Id, game.Id);
            var botsSteps = await GetAllStepOfBotsByGameId(game.Id);

            var steps = new List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
            var cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryView>();

            for (int i = 0; i < CountOfSteps; i++)
            {
                cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryView>();

                if (playerSteps.PlayerSteps.Count > i)
                {
                    cards.Add(new CardPlayerAndBotStepsDetailsOfGameHistoryView()
                    {
                        Id = playerSteps.PlayerSteps[i].Id,
                        Suite = playerSteps.PlayerSteps[i].Suite,
                        Rank = playerSteps.PlayerSteps[i].Rank,
                        Player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = playerSteps.PlayerSteps[i].Player.PlayerId,
                            UserName = playerSteps.PlayerSteps[i].Player.UserName,
                            Balance = playerSteps.PlayerSteps[i].Player.Balance,
                            Bet = playerSteps.PlayerSteps[i].Player.Bet
                        },
                        Game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = game.Id,
                            WonName = game.WonName,
                            GameState = game.GameState
                        },
                        Bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = new Guid(),
                            Name = "",
                            Balance = 0,
                            Bet = 0
                        }
                    });
                }
                foreach (var bot in bots.Bots)
                {
                    var countOfBotSteps = botsSteps.BotSteps
                        .Where(b => b.Bot.Id == bot.Id)
                        .ToList()
                        .Count;
                    if (countOfBotSteps > i)
                    {
                        cards.Add(new CardPlayerAndBotStepsDetailsOfGameHistoryView()
                        {
                            Id = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Id,
                            Suite = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Suite,
                            Rank = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Rank,
                            Player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = "",
                                UserName = "",
                                Balance = 0,
                                Bet = 0
                            },
                            Game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = game.Id,
                                WonName = game.WonName,
                                GameState = game.GameState
                            },
                            Bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView()
                            {
                                Id = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Bot.Id,
                                Name = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Bot.Name,
                                Balance = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Bot.Balance,
                                Bet = botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList()[i].Bot.Bet
                            }
                        });
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

            var botsDetails = new BotsGetStepsDetailsOfGameHistoryView()
            {
                Bots = new List<BotBotsGetStepsDetailsOfGameHistoryViewItem>()
            };
            botsDetails.Bots = bots.Bots.Select(bot => new BotBotsGetStepsDetailsOfGameHistoryViewItem()
            {
                Id = bot.Id,
                Name = bot.Name,
                Balance = bot.Balance,
                Bet = bot.Bet
            }).ToList();

            var steps = await GetStepsDetailsOfGame(gameDetails, botsDetails);

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
