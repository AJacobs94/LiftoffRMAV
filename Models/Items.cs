using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiftoffRMAV.Models
{
    public class Items
    {
        public int GamesID { get; set; }
        public int ID { get; set; }
        public Games Games { get; set; }

        public int UserId { get; set; }
       public RmavUser User { get; set; }
    }
}
