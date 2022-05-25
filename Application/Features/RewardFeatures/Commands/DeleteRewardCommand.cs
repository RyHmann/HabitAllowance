using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RewardFeatures.Commands
{
    public class DeleteRewardCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteRewardCommandHandler : IRequestHandler<DeleteRewardCommand, int>
        {
            private readonly IApplicationDbContext context;
            public DeleteRewardCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteRewardCommand command, CancellationToken cancellationToken)
            {
                var reward = await context.Rewards.Where(r => r.Id == command.Id).FirstOrDefaultAsync();
                if (reward == null) return default;
                context.Rewards.Remove(reward);
                await context.SaveChanges();
                return reward.Id;
            }
        }
    }
}
