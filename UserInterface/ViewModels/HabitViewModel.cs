using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class HabitViewModel : BaseViewModel
    {
        public List<HabitRoutine> HabitRoutines { get; set; }
    }
}
