using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.HistoryViews;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;
        private readonly IGameService _gameService;

        public HistoryController(IHistoryService historyService, IGameService gameService)
        {
            _historyService = historyService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await Execute(async () =>
            {
                var games = await _historyService.GetHistoryOfGames();
                return games;
            });
            return result;
        }

        public async Task<IActionResult> Game(string gameId)
        {
            var result = await Execute(async () =>
            {
                var game = await _historyService.DetailsOfGame(gameId);
                var playerSteps = await _gameService.GetAllSteps(game.Player.Id, game.Id);
                var botsSteps = await _gameService.GetAllStepOfBots(game.Id);
                var bots = await _gameService.GetAllBotsInGame(game.Id);

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
                                WonId = game.WonId,
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
                                    WonId = game.WonId,
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

                var model = new DetailsOfGameHistoryView()
                {
                    Game = game,
                    PlayerSteps = playerSteps,
                    BotsSteps = botsSteps,
                    PlayerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView()
                    {
                        Steps = steps
                    }
                };
                return model;
            });
            return result;
        }
    }
}