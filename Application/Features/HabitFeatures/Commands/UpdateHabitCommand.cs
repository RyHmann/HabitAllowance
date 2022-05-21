using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitFeatures.Commands
{
    public class UpdateHabitCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateHabitCommandHandler : IRequestHandler<UpdateHabitCommand, int>
        {
            private readonly IApplicationDbContext context;

            public UpdateHabitCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateHabitCommand command, CancellationToken cancellationToken)
            {
                var habit = context.Habits.Where(a => a.Id == command.Id).FirstOrDefault();
                if (habit == null) return default;
                else
                {
                    habit.Title = command.Title;
                    habit.Description = command.Description;
                    await context.SaveChanges();
                    return habit.Id;
                }
            }
        }
    }
}
