namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewTitle { get; set; }
        public string Message { get; set; }
        public Season Reviewed { get; set; }
        public User Reviewer { get; set; }
    }
}