using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
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

        public GameController(UserManager<Player> userManager, IPlayerService userService)
        {
            _userManager = userManager;
            _userService = userService;
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
                    StartGameResponseView gameDetailsVM = new StartGameResponseView()
                    {

                    };
                    return View("Start", gameDetailsVM);
                }
                else
                {
                }
                return View();
            }
            /*catch (ValidationException ex)
            {
                return RedirectToAction("Index", "Home", ex.Property);
            }*/
            catch
            {
                return RedirectToAction("Index", "Game");
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