using Application.Features.HabitEventFeatures.Commands;
using Application.Features.HabitEventFeatures.Queries;
using Application.Features.HabitRoutineFeatures.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class HabitEventController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHabitEventQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHabitEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHabitEventCommand command)
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
            return Ok(await Mediator.Send(new DeleteHabitEventCommand { Id = id }));
        }
    }
}
