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
    public partial class HabitRoutineDetail
    {
        [Inject]
        public IHabitRoutineDataService HabitRoutineDataService { get; set; }
        [Inject]
        public IRewardDataService RewardDataService { get; set; }
        public HabitRoutine HabitRoutine { get; set; } = new HabitRoutine();
        public HabitEventReward Reward { get; set; }
        [Parameter]
        public string HabitRoutineId { get; set; }
        private int habitRoutineIdInt
        {
            get { return int.Parse(HabitRoutineId); }
        }
        public decimal RewardAmount { get; set; }
        protected override async Task OnInitializedAsync()
        {
            RewardAmount = RewardDataService.GetReward();
            HabitRoutine = await HabitRoutineDataService.GetHabitRoutineById(habitRoutineIdInt);
        }

    }
}
