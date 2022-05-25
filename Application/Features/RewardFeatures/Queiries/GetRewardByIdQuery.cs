using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RewardFeatures.Queiries
{
    public class GetRewardByIdQuery : IRequest<Reward>
    {
        public int Id { get; set; }
        public class GetRewardByIdQueryHandler : IRequestHandler<GetRewardByIdQuery, Reward>
        {
            private readonly IApplicationDbContext context;

            public GetRewardByIdQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Reward> Handle(GetRewardByIdQuery query, CancellationToken cancellationToken)
            {
                var reward = context.Rewards
                    .Where(r => r.Id == query.Id)
                    .FirstOrDefaultAsync();
                if (reward == null) return null;
                return await reward;
            }
        }
    }
}
