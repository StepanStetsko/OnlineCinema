using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WatchStatus
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Season Season { get; set; }
        public string? Status { get; set; }
    }
}
