using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LiftoffRMAV.Models
{
    public class RmavRole : IdentityRole<int>
    {
        public RmavRole(){}
        
        public RmavRole(string name)
    {
        Name = name;
      }
    }
}
