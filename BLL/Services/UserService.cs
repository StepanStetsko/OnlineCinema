using DLL.Repository;
using Domain.Models;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly SeasonRepository _seasonRepository;

        public UserService(UserRepository userRepository, SeasonRepository seasonRepository)
        {
            _userRepository = userRepository;
            _seasonRepository = seasonRepository;
        }

        public async Task AddToFavorite(int seasonId, string currentUserId)
        {
            var userTemp = (await _userRepository.GetWhere(x => x.Id == currentUserId)).First();
            var seasonTemp = (await _seasonRepository.GetWhere(x => x.Id == seasonId)).First();

            userTemp.Favorite.Add(seasonTemp);
            await _userRepository.Update(userTemp);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userTemp = await _userRepository.GetAllAsync();
            return userTemp;
        }
        public async Task<IEnumerable<User>> GetUserByCondition(Expression<Func<User, bool>> predicate)
        {
            var userTemp = await _userRepository.GetWhere(predicate);
            return userTemp;
        }

        public async Task RemoveFromFavorite(int seasonId, string currentUserId)
        {
            var userTemp = (await _userRepository.GetWhere(x => x.Id == currentUserId)).First();
            var seasonTemp = (await _seasonRepository.GetWhere(x => x.Id == seasonId)).First();

            userTemp.Favorite.Remove(seasonTemp);
            await _userRepository.Update(userTemp);
        }

        public async Task UpdateWatchStatus(WatchStatus status, User currentUser, string newStatus)
        {
            status.Status = newStatus;
            currentUser.UserWatchList.Add(status);
            await _userRepository.Update(currentUser);
        }

        public async Task RemoveWatchStatus(WatchStatus status, User currentUser)
        {
            currentUser.UserWatchList.Remove(status);
            await _userRepository.Update(currentUser);
        }

        public async Task UpdateUserInfo(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task RemoveUser(User user)
        {
            await _userRepository.Delete(user);
        }
    }
}
