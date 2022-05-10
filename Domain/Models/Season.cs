using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float ImdbRating { get; set; }
        public float LocalRating { get; set; }
        public byte AgeRating { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
        public string TrailerUrl { get; set; }
        public string PosterUrl { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Person> Cast { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
