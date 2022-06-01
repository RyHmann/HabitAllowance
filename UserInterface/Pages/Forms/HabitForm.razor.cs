using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Pages.Forms
{
    public partial class HabitForm
    {
        [Inject]
        public IHabitDataService HabitDataService { get; set; }
        public Habit Habit { get; set; } = new Habit();
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        private void OnValidSubmit()
        {
            throw new NotImplementedException();
        }
    }
}
