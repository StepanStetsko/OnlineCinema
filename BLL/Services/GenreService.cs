using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class GenreService
    {
        private readonly GenreRepository _repository;
        public GenreService(GenreRepository genreRepository)
        {
            _repository = genreRepository;
        }
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<Season>> GetSeasonByGenreAsync(string genreName)
        {
            var genreTemp = await _repository.GetWhere(x => x.GenreName == genreName);

            return genreTemp.First().Relationships;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _repository.Create(genre);
        }
        public async Task DeleteGenreAsync(Genre genre)
        {
            await _repository.Delete(genre);
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
            await _repository.Update(genre);
        }
    }
}
