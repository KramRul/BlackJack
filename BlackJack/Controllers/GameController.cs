﻿using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
using BlackJack.ViewModels;
using BlackJack.ViewModels.GameViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly IPlayerService _userService;
        private readonly IGameService _gameService;

        public GameController(UserManager<Player> userManager, IPlayerService userService, IGameService gameService)
        {
            _userManager = userManager;
            _userService = userService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Start(StartGameView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var game = await _gameService.Start(model.Player.PlayerId, model.CountOfBots);
                    var playerSteps = await _gameService.GetAllSteps(model.Player.PlayerId, game.Id);
                    var botsSteps = await _gameService.GetAllStepOfBots(game.Id);
                    var result = new StartGameResultView()
                    {
                        Game = game,
                        PlayerSteps = playerSteps,
                        BotsSteps = botsSteps
                    };
                    return View("Start", result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                var response = new GenericResponseView<string>();
                response.Error = ex.Message;
                return BadRequest(response);
            }

        }

        /*[HttpGet]
        public IActionResult StartGame(GameViewModel gameVM)
        {
            try
            {
                return View(gameVM);
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Index", "Home", ex.Property);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }*/
    }
}