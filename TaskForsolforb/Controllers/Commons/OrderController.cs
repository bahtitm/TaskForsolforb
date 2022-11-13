using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApp.Application.Modules.Commons.Orders.Commands.CreateOrder;
using WebApp.Application.Modules.Commons.Orders.Commands.DeleteOrder;
using WebApp.Application.Modules.Commons.Orders.Commands.UpdateOrder;
using WebApp.Application.Modules.Commons.Orders.Queries.GetAllOrders;
using WebApp.Application.Modules.Commons.Orders.Queries.GetOrderDetail;

namespace TaskForsolforb.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для региона")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllOrdersQuery());
            return Ok(dataSource.AsQueryable());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await mediator.Send(new GetOrderDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrderCommand command)
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
            await mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
    }
}
