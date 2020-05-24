using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LiftoffRMAV.Models;

namespace LiftoffRMAV.Data
{
    public class ApplicationDbContext : IdentityDbContext<RmavUser,RmavRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RmavUser>().Ignore(e => e.FullName);
        }
    }
}
