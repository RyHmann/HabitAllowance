using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Pages.Habits
{
    public partial class HabitAdd
    {
        public Habit Habit { get; set; } = new Habit();
        [Inject]
        public IHabitDataService HabitDataService { get; set; }

        protected string StatusClass = string.Empty;
        protected string StatusMessage = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            Habit? newHabit = await HabitDataService.AddHabit(Habit);
            if (newHabit != null)
            {
                StatusClass = "alert-success";
                StatusMessage = "New habit added successfully";
                Saved = true;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            Saved = false;
            StatusClass = "alert-danger";
            StatusMessage = "There were some validation errors. Please try again";
        }
    }
}
