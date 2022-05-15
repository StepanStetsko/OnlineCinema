﻿namespace Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<Season> Relationships { get; set; }
    }
}