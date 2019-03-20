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
        public HistoryService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GameDetailsOfGameHistoryView> DetailsOfGame(string gameId)
        {
            var game = await _database.Games.Get(Guid.Parse(gameId));
            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var result = new GameDetailsOfGameHistoryView()
            {
                Id = game.Id,
                GameState = (GameStateTypeEnumView)game.GameState,
                WonName = game.WonName,
                Player = new PlayerDetailsOfGameHistoryView()
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

        public async Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GameDetailsOfGameHistoryView game,
            GetAllStepsGameView playerSteps,
            GetAllStepOfBotsGameView botsSteps,
            GetAllBotsInGameGameView bots)
        {
            var steps = new List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
            var cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryView>();

            for (int i = 0; i < 5; i++)
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
                    if (botsSteps.BotSteps.Where(b => b.Bot.Id == bot.Id).ToList().Count > i)
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
    }
}
