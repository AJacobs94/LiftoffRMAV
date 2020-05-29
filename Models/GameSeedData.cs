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
                if (context.Games.Any())
                {
                    return;
                }
                context.Games.AddRange(
                    new Games
                    {
                        Title="Assassin's Creed",
                        Genre="Action/Adventure",
                        Price=9.99M
                    },
                    new Games
                    {
                        Title="Fallout New Vegas",
                        Genre="Action/Adventure",
                        Price=14.99M
                    },
                    new Games
                    {
                        Title="Horizon,Zero,Dawn",
                        Genre="Action/Adventure",
                        Price=19.99M
                    },
                    new Games
                    {
                        Title = "Far Cry",
                        Genre = "Action/Adventure",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Ark",
                        Genre = "Survival",
                        Price = 19.99M
                    },
                    new Games
                    {
                        Title = "No Man's Sky",
                        Genre = "Survival",
                        Price = 19.99M
                    },
                    new Games
                    {
                        Title = "Battlefield",
                        Genre = "First-Person shooter",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Overwatch",
                        Genre = "First-Person shooter",
                        Price = 14.99M
                    },
                    new Games
                    {
                        Title = "Halo 5",
                        Genre = "First-Person shooter",
                        Price = 14.99M
                    },
                    new Games
                    {
                        Title = "Rainbow Six",
                        Genre = "First-Person shooter",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Metal Gear Solid",
                        Genre = "Stealth",
                        Price = 19.99M
                    },
                    new Games
                    {
                        Title = "Hitman",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Thief",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Dishonored",
                        Genre = "Stealth",
                        Price = 9.99M
                    },
                    new Games
                    {
                        Title = "Stardew Valley",
                        Genre = "Life Simulation",
                        Price = 19.99M
                    },
                    new Games
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
