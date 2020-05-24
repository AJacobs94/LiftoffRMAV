using LiftoffRMAV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LiftoffRMAV.Models
{
    public static class GameSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Search.Any())
                {
                    return;
                }
                context.Search.AddRange(
                    new Search
                    {
                        Title="Assassin's Creed",
                        Genre="Action/Adventure",
                        Price=9.99M
                    }
                    );
            }
        }
    }
}
