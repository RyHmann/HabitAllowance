using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces
{
    public interface IHabitEventDataService
    {
        Task<HabitEvent> AddHabitEvent(HabitEvent habitEvent);
        Task<HabitEvent> GetHabitEventById(int id);
        Task UpdateHabitEvent(HabitEvent habitEvent);
        Task<string> DeleteHabitEventById(HabitEvent habitEvent);
    }
}
