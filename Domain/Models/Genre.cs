﻿namespace Domain.Models
{
    internal class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<Season> Relationships { get; set; }
    }
}