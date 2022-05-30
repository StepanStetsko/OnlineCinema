using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;
        public MovieService(MovieRepository repository)
        {
            _movieRepository = repository;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.GetAllAsync();
        }
        public async Task<Movie> ShowDetails(int movieId)
        {
            var seasonTemp = await _movieRepository.GetWhere(x => x.Id == movieId);
            return seasonTemp.First();
        }
    }
}
