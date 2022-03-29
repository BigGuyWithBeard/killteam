using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KillTeam.WebMVC.Models
{
    public class Minifigure
    {
        public Guid Id { get; set; }
        public string Rfid {get; set; }
        public string Description { get; set; }
        public string Image { get;set; }


    }
}
