using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<HabitEvent> HabitEvents { get; set; }
        public virtual DbSet<HabitRoutine> HabitRoutines { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Habit>();
            builder.Entity<HabitRoutine>();
            builder.Entity<HabitEvent>();
            builder.Entity<Reward>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }


    }
}
