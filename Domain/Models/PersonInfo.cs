namespace Domain.Models
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }     
    }
}