using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HabitRoutine : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int HabitId { get; set; }
        [JsonIgnore]
        public Habit Habit { get; set; }
        public List<HabitEvent> HabitEvents { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
