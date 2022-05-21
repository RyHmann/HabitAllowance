using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HabitEventFeatures.Queries
{
    public class GetHabitEventQuery : IRequest<HabitEvent>
    {
        public int Id { get; set; }
        public class GetHabitEventQueryHandler : IRequestHandler<GetHabitEventQuery, HabitEvent>
        {
            private readonly IApplicationDbContext context;

            public GetHabitEventQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<HabitEvent> Handle(GetHabitEventQuery query, CancellationToken cancellationToken)
            {
                var habitEvent = context.HabitEvents.Where(h => h.Id == query.Id).FirstOrDefaultAsync();
                if (habitEvent == null) return null;
                return await habitEvent;
            }
        }
    }
}
