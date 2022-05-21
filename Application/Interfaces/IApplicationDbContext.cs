﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Habit> Habits { get; set; }
        DbSet<HabitEvent> HabitEvents { get; set; }
        DbSet<HabitEventReward> HabitEventRewards { get; set; }
        DbSet<HabitRoutine> HabitRoutines { get; set; }
        Task<int> SaveChanges();
    }
}
