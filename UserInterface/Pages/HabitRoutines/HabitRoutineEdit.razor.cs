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
    public partial class HabitRoutineEdit
    {
        [Inject]
        public IHabitRoutineDataService HabitRoutineDataService { get; set; } 
        [Parameter]
        public string HabitRoutineId { get; set; }
        private int habitRoutineId
        {
            get { return int.Parse(HabitRoutineId); }
        }
        public HabitRoutine HabitRoutine { get; set; } = new HabitRoutine();
        protected bool Saved;
        protected bool DeleteConfirm;
        protected string Status = string.Empty;
        protected string StatusClass = string.Empty;
        protected string StatusMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            DeleteConfirm = false;
            HabitRoutine = await HabitRoutineDataService.GetHabitRoutineById(habitRoutineId);
        }
        protected async Task HandleValidSubmit()
        {
            Saved = false;
            await HabitRoutineDataService.UpdateHabitRoutine(HabitRoutine);
        }
        protected async Task HandleInvalidSubmit()
        {
            Saved = false;
            StatusClass = "alert-danger";
        }
        protected async Task DeleteRoutine()
        {
            var habitTitle = await HabitRoutineDataService.DeleteHabitRoutineById(HabitRoutine);
        }
    }
}
