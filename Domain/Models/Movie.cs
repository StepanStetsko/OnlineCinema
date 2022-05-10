namespace Domain.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public short Timing { get; set; }
        public string Description { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public string PosterUrl { get; set; }
        public string MovieUrl { get; set; }
    }
}