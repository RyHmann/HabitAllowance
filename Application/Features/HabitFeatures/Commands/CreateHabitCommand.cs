using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitFeatures.Commands
{
    public class CreateHabitCommand : IRequest<Habit>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreateHabitCommanHandler : IRequestHandler<CreateHabitCommand, Habit>
        {
            public IApplicationDbContext context { get; }
            public CreateHabitCommanHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Habit> Handle(CreateHabitCommand command, CancellationToken cancellationToken)
            {
                var habit = new Habit();
                habit.Title = command.Title;
                habit.Description = command.Description;
                context.Habits.Add(habit);
                await context.SaveChanges();
                return habit;
            }
        }
    }
}
