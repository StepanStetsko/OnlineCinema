using BLL.Services;
using Domain.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCinema.Controllers
{
    public class MediaController : Controller
    {
        private readonly SeasonService _seasonService;
        private readonly MovieService _movieService;
        private readonly PersonService _personService;
        private readonly GenreService _genreService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MediaController(SeasonService seasonService, MovieService movieService, PersonService personService, GenreService genreService, IWebHostEnvironment hostEnvironment)
        {
            _seasonService = seasonService;
            _movieService = movieService;
            _personService = personService;
            _genreService = genreService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> DetailsAsync(int seasonId)
        {
            return View(await _seasonService.ShowDetails(seasonId));
        }  

        public async Task<JsonResult> Detail(string option, int id)
        {
            switch (option)
            {
                case "season":
                    return Json(await _seasonService.ShowDetails(id));
                case "person":
                    return Json(await _personService.ShowDetailsAsync(id));
                case "movie":
                    return Json(await _movieService.ShowDetails(id));                
            }

            return Json(NotFound().StatusCode);
        }

        public async Task<JsonResult> GetMedia(string order)
        {
            switch (order)
            {
                case "by_view":
                    return Json((await _seasonService.GetSeasons()).OrderBy(x => x.Views).Take(10));

                case "by_year":
                    return Json((await _seasonService.GetSeasons()).OrderBy(x => x.DateStart.Date.Year == DateTime.Now.Year).ThenBy(y => y.LocalRating >= 6.0).Take(10));

                case "popular":
                    return Json((await _seasonService.GetSeasons()).OrderBy(x => x.LocalRating >= 6).Take(10));

                case "latest_episode":
                    return Json((await _movieService.GetMovies()).OrderBy(x => x.UploadDate).Take(15));
            }

            return Json(await _seasonService.GetSeasons());
        }

        public async Task<JsonResult> GetAllGenre()
        {
            return Json(await _genreService.GetGenresAsync());
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateNewSeason(Season season, IFormFile poster)
        {
            string seasonPath = Path.Combine("Seasons", season.Title);

            Directory.CreateDirectory(Path.Combine(_hostEnvironment.WebRootPath, seasonPath));
            season.SeasonUrl = seasonPath;
            season.PosterUrl = Path.Combine(seasonPath, poster.FileName);

            using (FileStream stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, season.PosterUrl), FileMode.Create))
            {
                await poster.CopyToAsync(stream);
            }

            await _seasonService.CreateSeasonAsync(season);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public async void AddMovie(Movie movie, int seasonId, IFormFile file)
        {
            var seasonTemp = (await _seasonService.GetSeasonBy(x => x.Id == seasonId)).First();

            if (seasonTemp == null) return;

            movie.MovieUrl = seasonTemp.SeasonUrl + file.FileName;
            using (FileStream stream = new FileStream(movie.MovieUrl, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _seasonService.AddMovie(seasonId, movie);
        }

        [Authorize(Roles = "Administrator")]
        public async void AddPerson(Person person, IFormFile photo)
        {
            string personPath = "/Person/" + person.PersonInfo.Name + person.PersonInfo.Surname;
            Directory.CreateDirectory(personPath);

            using (FileStream stream = new FileStream(personPath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            await _personService.AddPersonAsync(person);
        }

    }
}
