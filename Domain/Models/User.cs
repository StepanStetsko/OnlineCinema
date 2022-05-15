using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public List<Season> Library { get; set; }
        public List<Review> Reviews { get; set; }
    }
}