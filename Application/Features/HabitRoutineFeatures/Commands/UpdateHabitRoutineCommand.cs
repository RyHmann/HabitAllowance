using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitRoutineFeatures.Commands
{
    public class UpdateHabitRoutineCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public class UpdateHabitRoutineCommandHandler : IRequestHandler<UpdateHabitRoutineCommand, int>
        {
            private readonly IApplicationDbContext context;

            public UpdateHabitRoutineCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateHabitRoutineCommand command, CancellationToken cancellationToken)
            {
                var routine = context.HabitRoutines.Where(r => r.Id == command.Id).FirstOrDefault();
                if (routine == null) return default;
                else
                {
                    routine.Title = command.Title;
                    routine.Description = command.Description;
                    await context.SaveChanges();
                    return routine.Id;
                }
            }
        }
    }
}
