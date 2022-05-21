using Application.Features.HabitRoutineFeatures.Commands;
using Application.Features.HabitRoutineFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class HabitRoutineController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHabitRoutineByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHabitRoutineCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHabitRoutineCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await Mediator.Send(new DeleteHabitRoutineCommand { Id = id }));
        }
    }
}
