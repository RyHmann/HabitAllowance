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
    public partial class HabitEventEdit
    {
        [Inject]
        public IHabitEventDataService HabitEventDataService { get; set; }
        [Parameter]
        public string HabitEventId { get; set; }
        private int habitEventIdInt
        {
            get { return int.Parse(HabitEventId); }
        }
        public HabitEvent HabitEvent { get; set; } = new HabitEvent();
        protected bool Saved;
        protected bool DeleteConfirm;
        protected string Status = string.Empty;
        protected string StatusClass = string.Empty;
        protected string StatusMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            DeleteConfirm = false;
            HabitEvent = await HabitEventDataService.GetHabitEventById(habitEventIdInt);
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            await HabitEventDataService.UpdateHabitEvent(HabitEvent);
        }
        protected async Task HandleInvalidSubmit()
        {
            Saved = false;
            StatusClass = "alert-danger";
        }

        protected async Task DeleteHabitEvent()
        {
            var eventTitle = await HabitEventDataService.DeleteHabitEventById(HabitEvent);
        }
    }
}
