namespace Domain.Models
{
    public class Season
    {
        public Season()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User> LikedByUsers { get; set; } = new List<User>();
        public string Type { get; set; }
        public int Views { get; set; }
        public string Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float ImdbRating { get; set; }
        public float LocalRating { get; set; }
        public byte AgeRating { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
        public string SeasonUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string PosterUrl { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Person> Cast { get; set; } = new List<Person>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
