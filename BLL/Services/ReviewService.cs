using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task LoadRewiew(Season season)
        {
            await _reviewRepository.GetWhere(x => x.Reviewed.Id == season.Id);
        }
        public async Task AddRewiew(Review review)
        {
            await _reviewRepository.Create(review);
        }
        public async Task DeleteRewiew(Review review)
        {
            await _reviewRepository.Delete(review);
        }
        public async void EditReview(Review review)
        {
            await _reviewRepository.Update(review);
        }
    }
}
