using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitRoutineFeatures.Commands
{
    public class CreateHabitRoutineCommand : IRequest<HabitRoutine>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int HabitId { get; set; }
        public class CreateHabitRoutineCommandHandler : IRequestHandler<CreateHabitRoutineCommand, HabitRoutine>
        {
            private readonly IApplicationDbContext context;

            public CreateHabitRoutineCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<HabitRoutine> Handle(CreateHabitRoutineCommand command, CancellationToken cancellationToken)
            {
                var routine = new HabitRoutine();
                routine.Title = command.Title;
                routine.Description = command.Description;
                routine.HabitId = command.HabitId;
                context.HabitRoutines.Add(routine);
                await context.SaveChanges();
                return routine;
            }
        }
    }
}
