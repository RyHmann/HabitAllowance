using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitFeatures.Queries
{
    public class GetHabitByIdQuery : IRequest<Habit>
    {
        public int Id { get; set; }
        public class GetHabitByIdQueryHandler : IRequestHandler<GetHabitByIdQuery,Habit>
        {
            private readonly IApplicationDbContext context;
            public GetHabitByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Habit> Handle(GetHabitByIdQuery query, CancellationToken token)
            {
                var habit = context.Habits
                    .Include(ht => ht.HabitRoutines)
                    .Where(h => h.Id == query.Id)
                    .FirstOrDefaultAsync();
                if (habit == null) return null;
                return await habit;
            }
        }
    }
}
