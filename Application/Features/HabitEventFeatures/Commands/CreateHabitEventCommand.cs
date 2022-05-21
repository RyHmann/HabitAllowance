using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitEventFeatures.Commands
{
    public class CreateHabitEventCommand : IRequest<HabitEvent>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int HabitRoutineId { get; set; }

        public class CreateHabitEventCommandRequest : IRequestHandler<CreateHabitEventCommand, HabitEvent>
        {
            private readonly IApplicationDbContext context;

            public CreateHabitEventCommandRequest(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<HabitEvent> Handle(CreateHabitEventCommand command, CancellationToken cancellationToken)
            {
                var entity = new HabitEvent()
                {
                    Title = command.Title,
                    Description = command.Description,
                    HabitRoutineId = command.HabitRoutineId,
                    EffectiveDate = command.EffectiveDate
                };
                context.HabitEvents.Add(entity);
                await context.SaveChanges();
                return entity;
            }
        }
    }
}
