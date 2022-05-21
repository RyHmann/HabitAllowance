using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitEventFeatures.Commands
{
    public class DeleteHabitEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHabitEventCommandHandlder : IRequestHandler<DeleteHabitEventCommand, int>
        {
            private readonly IApplicationDbContext context;

            public DeleteHabitEventCommandHandlder(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(DeleteHabitEventCommand command, CancellationToken cancellationToken)
            {
                var habitEvent = await context.HabitEvents.Where(e => e.Id == command.Id).FirstOrDefaultAsync();
                if (habitEvent == null) return default;
                context.HabitEvents.Remove(habitEvent);
                await context.SaveChanges();
                return habitEvent.Id;
            }
        }
    }
}
