using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public List<WatchStatus> UserWatchList { get; set; } = new List<WatchStatus>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Season> Favorite { get; set; } = new List<Season>();
    }
}