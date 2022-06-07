using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;

namespace WebApp.Pages.Habits
{
    public partial class HabitEdit
    {
        [Inject]
        IHabitDataService HabitDataService { get; set; }
        [Parameter]
        public string HabitId { get; set; }
        private int habitIdInt
        {
            get { return int.Parse(HabitId); }
        }
        public Habit Habit { get; set; } = new Habit();
        protected bool Saved;
        protected bool DeleteConfirm;
        protected string Status = string.Empty;
        protected string StatusClass = string.Empty;
        protected string StatusMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            DeleteConfirm = false;
            Habit = await HabitDataService.GetHabitById(habitIdInt);
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            await HabitDataService.UpdateHabit(Habit);
        }

        protected async Task HandleInvalidSubmit()
        {
            Saved = false;
            StatusClass = "alert-danger";
        }

        protected async Task DeleteHabit()
        {
            var habitTitle = await HabitDataService.DeleteHabitById(Habit);
        }
    }
}
