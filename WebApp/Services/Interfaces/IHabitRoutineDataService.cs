using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces
{
    public interface IHabitRoutineDataService
    {
        Task<HabitRoutine> AddHabitRoutine(HabitRoutine habitRoutine);
        Task<HabitRoutine> GetHabitRoutineById(int id);
        Task UpdateHabitRoutine(HabitRoutine habitRoutine);
        Task<string> DeleteHabitRoutineById(HabitRoutine habitRoutine);
    }
}
