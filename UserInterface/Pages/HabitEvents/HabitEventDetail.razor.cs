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
    public partial class HabitEventDetail
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

        protected override async Task OnInitializedAsync()
        {
            HabitEvent = await HabitEventDataService.GetHabitEventById(habitEventIdInt);
        }


    }
}
