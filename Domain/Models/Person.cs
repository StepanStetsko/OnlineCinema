namespace Domain.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public string Role { get; set; }
        public List<Season> VideoCatalog { get; set; }
    }
}