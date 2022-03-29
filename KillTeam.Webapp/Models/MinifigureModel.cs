using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace KillTeam.WebApp.Models
{
    public class MinifigureModel
    {
        public Guid Id { get; set; }
        public string RfidKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get;set; }


    }
}
