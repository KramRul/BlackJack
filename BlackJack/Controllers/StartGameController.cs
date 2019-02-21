using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
using BlackJack.ViewModels.StartGameViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.WEB.Controllers
{
    public class StartGameController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly IPlayerService _userService;

        public StartGameController(UserManager<Player> userManager, IPlayerService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> StartGame(StartGameHomeView model)
        {
            try
            {
                if (ModelState.IsValid && User.Identity.IsAuthenticated)
                {
                    StartGameHomeResponseView gameDetailsVM = new StartGameHomeResponseView()
                    {

                    };
                    return View("StartGame", gameDetailsVM);
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
                return RedirectToAction("Index", "StartGame");
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