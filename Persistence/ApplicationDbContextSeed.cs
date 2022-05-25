using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ApplicationDbContextSeed
    {
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
