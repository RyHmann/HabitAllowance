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
    public class GetAllHabitsQuery : IRequest<IEnumerable<Habit>>
    {
        public class GetAllHabitsQueryHander : IRequestHandler<GetAllHabitsQuery, IEnumerable<Habit>>
        {
            private readonly IApplicationDbContext context;
            public GetAllHabitsQueryHander(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Habit>> Handle(GetAllHabitsQuery request, CancellationToken cancellationToken)
            {
                // TODO: I assume this method goes away when Users are added...
                var habitList = await context.Habits
                    .Include(r => r.HabitRoutines)
                    .ToListAsync();
                if (habitList == null)
                {
                    return null;
                }
                return habitList.AsReadOnly();
            }
        }
    }
}
