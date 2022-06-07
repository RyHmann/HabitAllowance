using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces
{
    public interface IHabitDataService
    {
        Task<Habit> AddHabit(Habit habit);
        Task<IEnumerable<Habit>> GetAllHabits();
        Task<Habit> GetHabitById(int id);
        Task UpdateHabit(Habit habit);
        Task<string> DeleteHabitById(Habit habit);
    }
}
