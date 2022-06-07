using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("habit@localhost").Result==null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "habit@localhost",
                    Email = "habit@localhost"
                };

                IdentityResult result = userManager.CreateAsync(user, "Qwe123!@#").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            //var admin = new IdentityUser { UserName = "admin@localhost", Email = "admin@localhost" };
            //if (userManager.Users.All(u => u.UserName != admin.UserName))
            //{
            //    await userManager.CreateAsync(admin, "qwe123!@#");
            //}
        }
        
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Habits.Any())
            {
                context.Habits.Add(new Habit
                {
                    Title = "Running",
                    Description = "Build a running habit",
                    HabitRoutines = new List<HabitRoutine> 
                    { 
                        new HabitRoutine 
                        { 
                            Title = "Regular Jogs", Description = "Trying to jog more regulary", Reward = new Reward {Currency = 5.00M, RewardType = Domain.Enums.RewardType.Currency}
                        } 
                    }
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
