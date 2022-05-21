using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Pages.HabitEvents
{
    public partial class HabitEventAdd
    {
        [Inject]
        public IHabitEventDataService HabitEventDataService { get; set; }
        [Parameter]
        public string HabitRoutineId { get; set; }
        public HabitEvent HabitEvent { get; set; } = new HabitEvent();
        private int habitRoutineId
        {
            get { return int.Parse(HabitRoutineId); }
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
            this.HabitEvent.HabitRoutineId = habitRoutineId;
            HabitEvent? newEvent = await HabitEventDataService.AddHabitEvent(HabitEvent);
            if (newEvent != null)
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
