using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<HabitEvent> HabitEvents { get; set; }
        public virtual DbSet<HabitRoutine> HabitRoutines { get; set; }
        public virtual DbSet<HabitEventReward> HabitEventRewards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Habit>();
            builder.Entity<HabitRoutine>();
            builder.Entity<HabitEvent>();
            builder.Entity<HabitEventReward>();
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }


    }
}
