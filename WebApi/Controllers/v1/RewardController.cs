using Application.Features.RewardFeatures.Commands;
using Application.Features.RewardFeatures.Queiries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class RewardController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByInt(int id)
        {
            return Ok(await Mediator.Send(new GetRewardByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRewardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRewardCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRewardCommand { Id = id }));
        }
    }
}
