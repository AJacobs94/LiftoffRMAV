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
                    },
                    new Search
                    {
                        Title="Fallout New Vegas",
                        Genre="Action/Adventure",
                        Price=14.99M
                    },
                    new Search
                    {
                        Title="Horizon,Zero,Dawn",
                        Genre="Action/Adventure",
                        Price=19.99M
                    },
                    new Search
                    {
                        Title = "Far Cry",
                        Genre = "Action/Adventure",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Ark",
                        Genre = "Survival",
                        Price = 19.99M
                    },
                    new Search
                    {
                        Title = "No Man's Sky",
                        Genre = "Survival",
                        Price = 19.99M
                    },
                    new Search
                    {
                        Title = "Battlefield",
                        Genre = "First-Person shooter",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Overwatch",
                        Genre = "First-Person shooter",
                        Price = 14.99M
                    },
                    new Search
                    {
                        Title = "Halo 5",
                        Genre = "First-Person shooter",
                        Price = 14.99M
                    },
                    new Search
                    {
                        Title = "Rainbow Six",
                        Genre = "First-Person shooter",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Metal Gear Solid",
                        Genre = "Stealth",
                        Price = 19.99M
                    },
                    new Search
                    {
                        Title = "Hitman",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Thief",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Dishonored",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Search
                    {
                        Title = "Stardew Valley",
                        Genre = "Life Simulation",
                        Price = 19.99M
                    },
                    new Search
                    {
                        Title = "Sims 5",
                        Genre = "Life Simulation",
                        Price = 19.99M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
