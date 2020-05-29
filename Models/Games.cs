using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffRMAV.Models
{
    public class Games
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
