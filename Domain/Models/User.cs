using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public List<WatchStatus> UserWatchList { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Season> Favorite { get; set; }
    }
}