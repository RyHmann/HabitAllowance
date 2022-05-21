using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitRoutineFeatures.Commands
{
    public class DeleteHabitRoutineCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHabitRoutineCommandHandler : IRequestHandler<DeleteHabitRoutineCommand, int>
        {
            private readonly IApplicationDbContext context;

            public DeleteHabitRoutineCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteHabitRoutineCommand command, CancellationToken cancellationToken)
            {
                var routine = await context.HabitRoutines.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (routine == null) return default;
                context.HabitRoutines.Remove(routine);
                await context.SaveChanges();
                return routine.Id;
            }
        }
    }
}
