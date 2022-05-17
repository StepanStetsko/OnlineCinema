using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class SeasonService
    {
        private readonly SeasonRepository _seasonRepository;

        public SeasonService(SeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IEnumerable<Season>> GetSeasons()
        {
            return await _seasonRepository.GetAllAsync();
        }
        public async Task<Season> ShowDetails(int seasonId)
        {
            var seasonTemp = await _seasonRepository.GetWhere(x => x.Id == seasonId);
            return seasonTemp.First();
        }
        public async Task CreateSeason(Season season)
        {
            await _seasonRepository.Create(season);
        }
        public async Task UpdateSeason(Season season)
        {
            await _seasonRepository.Update(season);
        }
        public async Task DeleteSeason(Season season)
        {
            await _seasonRepository.Delete(season);
        }

        public async Task AddMovie(int seasonId, Movie movie)
        {
            var season = (await _seasonRepository.GetWhere(x => x.Id == seasonId)).First();
            season.Movies.Add(movie);
            await _seasonRepository.Update(season);
        }
        public async Task AddPerson(int seasonId, Person person)
        {
            var season = (await _seasonRepository.GetWhere(x => x.Id == seasonId)).First();
            season.Cast.Add(person);
            await _seasonRepository.Update(season);
        }
    }
}
