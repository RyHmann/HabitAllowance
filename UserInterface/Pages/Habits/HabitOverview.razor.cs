﻿using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Pages.Habits
{
    public partial class HabitOverview
    {
        public IEnumerable<Habit> Habits { get; set; }
        [Inject]
        public IHabitDataService HabitDataService { get; set; }
        public bool showRoutine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Habits = (await HabitDataService.GetAllHabits()).ToList();
        }

        private void ShowBtnPress(int habitId)
        {
            var habitClicked = Habits.First(f => f.Id == habitId);
            showRoutine = !showRoutine;
        }
    }
}
