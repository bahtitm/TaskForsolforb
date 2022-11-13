using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApp.Application.Modules.Commons.OrderItems.Commands.CreateOrderItem;
using WebApp.Application.Modules.Commons.OrderItems.Commands.UpdateOrderItem;
using WebApp.Application.Modules.Commons.OrderItems.Queries.GetAllRegions;
using WebApp.Application.Modules.Commons.OrderItems.Queries.GetOrderItemDetail;

namespace TaskForsolforb.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для района")]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllOrderItemsQuery());
            return Ok(dataSource.AsQueryable());
        }


        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await mediator.Send(new GetOrderItemDetailQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateOrderItemCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrderItemCommand command)
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
            await mediator.Send(new DeleteOrderItemCommand(id));
            return NoContent();
        }
    }
}
