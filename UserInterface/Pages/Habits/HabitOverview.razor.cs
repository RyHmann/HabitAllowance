using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;
using UserInterface.ViewModels;

namespace UserInterface.Pages.Habits
{
    public partial class HabitOverview
    {
        public IEnumerable<HabitViewModel> HabitViewModels { get; set; }
        [Inject]
        public IHabitDataService HabitDataService { get; set; }
        public List<HabitRoutine> ViewableRoutines { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userHabits = (await HabitDataService.GetAllHabits()).ToList();
            HabitViewModels = AssignHabitViewModels(userHabits);
        }

        private void ShowBtnPress(int habitId)
        {
            var selectedHabit = HabitViewModels.FirstOrDefault(h => h.Id == habitId);
            selectedHabit.isVisible = !selectedHabit.isVisible;
        }

        private HabitViewModel ghettoMapper(Habit habit)
        {
            var newHabitVM = new HabitViewModel();
            newHabitVM.Id = habit.Id;
            newHabitVM.Title = habit.Title;
            newHabitVM.Description = habit.Description;
            newHabitVM.HabitRoutines = habit.HabitRoutines;
            newHabitVM.isVisible = false;
            return newHabitVM;
        }
        private IEnumerable<HabitViewModel> AssignHabitViewModels(List<Habit> habits)
        {
            var habitVMs = new List<HabitViewModel>();
            foreach (var habit in habits)
            {
                habitVMs.Add(ghettoMapper(habit));
            }
            return habitVMs;
        }
    }
}
