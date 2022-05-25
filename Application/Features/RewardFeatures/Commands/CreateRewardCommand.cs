using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RewardFeatures.Commands
{
    public class CreateRewardCommand : IRequest<Reward>
    {
        public decimal Currency { get; set; }
        public RewardType RewardType { get; set; }
        public int Points { get; set; }
        public int HabitRoutineId { get; set; }

        public class CreateRewardCommandHandler : IRequestHandler<CreateRewardCommand, Reward>
        {
            private readonly IApplicationDbContext context;

            public CreateRewardCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<Reward> Handle(CreateRewardCommand command, CancellationToken cancellationToken)
            {
                // TODO: Need to confirm that only 1 reward is created per habitevent, I think this validation should take place in the domain layer
                var reward = new Reward();
                reward.Currency = command.Currency;
                reward.RewardType = command.RewardType;
                reward.Points = command.Points;
                reward.HabitRoutineId = command.HabitRoutineId;
                context.Rewards.Add(reward);
                await context.SaveChanges();
                return reward;
            }
        }
    }
}
