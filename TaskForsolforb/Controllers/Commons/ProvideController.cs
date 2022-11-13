using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApp.Application.Modules.Commons.Provides.Commands.CreateProvide;
using WebApp.Application.Modules.Commons.Provides.Commands.UpdateProvide;
using WebApp.Application.Modules.Commons.Provides.Dtos;
using WebApp.Application.Modules.Commons.Provides.Queries.GetAll;
using WebApp.Application.Modules.Commons.Provides.Queries.GetDetail;

namespace TaskForsolforb.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для региона")]
    public class ProvideController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProvideController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProvideDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllProvideQuery());
            return Ok(dataSource.AsQueryable());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProvideDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await mediator.Send(new GetProvideDetailQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProvideDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateProvideCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProvideDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProvideCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteProvideCommand(id));
            return NoContent();
        }
    }
}
