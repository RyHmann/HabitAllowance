using Application.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RewardFeatures.Commands
{
    public class UpdateRewardCommand : IRequest<int>
    {
        public int Id { get; set; }
        public decimal Currency { get; set; }
        public RewardType RewardType { get; set; }
        public int Points { get; set; }
        public int HabitRoutineId { get; set; }
        public class UpdateRewardCommandHandler : IRequestHandler<UpdateRewardCommand, int>
        {
            private readonly IApplicationDbContext context;

            public UpdateRewardCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateRewardCommand command, CancellationToken cancellationToken)
            {
                var reward = context.Rewards.Where(r => r.Id == command.Id).FirstOrDefault();
                if (reward == null) return default;
                else
                {
                    reward.Currency = command.Currency;
                    reward.RewardType = command.RewardType;
                    reward.Points = command.Points;
                    reward.HabitRoutineId = command.HabitRoutineId;
                    await context.SaveChanges();
                    return reward.Id;
                }
            }
        }
    }
}
