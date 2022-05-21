using Application.Features.HabitFeatures.Commands;
using Application.Features.HabitFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class HabitController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllHabitsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHabitByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHabitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHabitCommand command)
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
            return Ok(await Mediator.Send(new DeleteHabitCommand { Id = id }));
        }
    }
}
