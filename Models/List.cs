using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiftoffRMAV.Models
{
    public class List
    {
        public int GamesID { get; set; }
        public int ID { get; set; }
        public Games Games { get; set; }
       
    }
}
