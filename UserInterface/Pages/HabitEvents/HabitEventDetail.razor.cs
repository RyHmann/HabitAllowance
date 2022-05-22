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
        public string HabitEventDetailId { get; set; }
        private int habitEventDetailIdInt
        {
            get { return int.Parse(HabitEventDetailId); }
        }
        public HabitEvent HabitEvent { get; set; } = new HabitEvent();
    }
}
