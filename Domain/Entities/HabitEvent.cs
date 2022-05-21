using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HabitEvent : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int HabitRoutineId { get; set; }
        [JsonIgnore]
        public  HabitRoutine HabitRoutine { get; set; }
    }
}
