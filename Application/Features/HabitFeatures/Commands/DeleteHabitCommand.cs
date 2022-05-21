using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitFeatures.Commands
{
    public class DeleteHabitCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHabitCommandHandler : IRequestHandler<DeleteHabitCommand, int>
        {
            public IApplicationDbContext context { get; }
            public DeleteHabitCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(DeleteHabitCommand command, CancellationToken cancellationToken)
            {
                var habit = await context.Habits.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (habit == null) return default;
                context.Habits.Remove(habit);
                await context.SaveChanges();
                return habit.Id;
            }
        }
    }
}
