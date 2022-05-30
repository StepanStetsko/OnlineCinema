namespace Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UploadDate { get; set; }
        public short Timing { get; set; }
        public string Description { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public string PosterUrl { get; set; }
        public string MovieUrl { get; set; }
        public Season Season { get; set; }
    }
}