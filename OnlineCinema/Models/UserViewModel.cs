namespace OnlineCinema.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
