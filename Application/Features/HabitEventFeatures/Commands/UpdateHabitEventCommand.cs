using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitEventFeatures.Commands
{
    public class UpdateHabitEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int HabitRoutineId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public class UpdateHabitEventCommandHandler : IRequestHandler<UpdateHabitEventCommand, int>
        {
            private readonly IApplicationDbContext context;

            public UpdateHabitEventCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateHabitEventCommand command, CancellationToken cancellationToken)
            {
                var habitEvent = context.HabitEvents.Where(h => h.Id == command.Id).FirstOrDefault();
                if (habitEvent == null || command.HabitRoutineId == 0) return default;
                else
                {
                    habitEvent.Title = command.Title;
                    habitEvent.Description = command.Description;
                    habitEvent.EffectiveDate = command.EffectiveDate;
                    habitEvent.HabitRoutineId = command.HabitRoutineId;
                    await context.SaveChanges();
                    return habitEvent.Id;
                }
            }
        }
    }
}
