namespace Domain.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Season> Library { get; set; }
        public List<Review> Reviews { get; set; }
    }
}