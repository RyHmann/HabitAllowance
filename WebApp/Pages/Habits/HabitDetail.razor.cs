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
    public partial class HabitDetail
    {
        [Inject]
        public IHabitDataService HabitDataService { get; set; }
        public Habit Habit { get; set; } = new Habit();
        [Parameter]
        public string HabitId { get; set; }
        private int habitIdInt
        {
            get { return int.Parse(HabitId); }
        }
        protected override async Task OnInitializedAsync()
        {
            Habit = await HabitDataService.GetHabitById(habitIdInt);
        }
    }
}
