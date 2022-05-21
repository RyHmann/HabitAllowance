using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitRoutineFeatures.Queries
{
    public class GetHabitRoutineByIdQuery : IRequest<HabitRoutine>
    {
        public int Id { get; set; }
        public class GetHabitRoutineByIdQueryHandler : IRequestHandler<GetHabitRoutineByIdQuery, HabitRoutine>
        {
            private readonly IApplicationDbContext context;

            public GetHabitRoutineByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<HabitRoutine> Handle(GetHabitRoutineByIdQuery query, CancellationToken token)
            {
                var habitRoutine = context.HabitRoutines
                    .Include(e => e.HabitEvents)
                    .Where(i => i.Id == query.Id)
                    .FirstOrDefaultAsync();
                if (habitRoutine == null) return null;
                return await habitRoutine;
            }
        }
    }
}
