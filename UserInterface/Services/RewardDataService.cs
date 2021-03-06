using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Services
{
    public class RewardDataService : IRewardDataService
    {
        private readonly HttpClient httpClient;

        public RewardDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public decimal GetReward()
        {
            return 5.00M;
        }
    }
}
