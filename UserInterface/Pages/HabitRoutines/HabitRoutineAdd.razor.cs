using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Pages.HabitRoutines
{
    public partial class HabitRoutineAdd
    {
        [Inject]
        public IHabitRoutineDataService HabitRoutineDataService { get; set; }

        public HabitRoutine HabitRoutine { get; set; } = new HabitRoutine();
        // TODO: We need to inherit HabitId from Habit so that we can connect this Routine to its habit
        [Parameter]
        public string HabitId { get; set; }
        private int habitIdInt
        {
            get { return int.Parse(HabitId); }
        }
        
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
            this.HabitRoutine.HabitId = habitIdInt;
            HabitRoutine? newRoutine = await HabitRoutineDataService.AddHabitRoutine(HabitRoutine);
            if (newRoutine != null)
            {
                StatusClass = "alert-success";
                StatusMessage = "New routine added successfully";
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
