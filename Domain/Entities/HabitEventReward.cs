using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HabitEventReward : BaseEntity
    {
        [Column(TypeName ="money")]
        public decimal Currency { get; set; }
        public RewardType RewardType { get; set; }
        public int Points { get; set; }
        public int HabitRoutineId { get; set; }
        public virtual HabitRoutine HabitRoutine { get; set; }
    }
}
