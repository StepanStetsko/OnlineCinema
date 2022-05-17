using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Models;
using System.Diagnostics;

namespace OnlineCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeasonService _seasonService;

        public HomeController(ILogger<HomeController> logger, SeasonService seasonService)
        {
            _logger = logger;
            _seasonService = seasonService;
        }

        public async Task<IActionResult> Index()
        {
            var seasonsTemp = await _seasonService.GetSeasons();

            return View(seasonsTemp.ToList());
        }

        public async Task<IActionResult> Details(int seasonId)
        {
            var season = await _seasonService.ShowDetails(seasonId);

            return View(season);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}