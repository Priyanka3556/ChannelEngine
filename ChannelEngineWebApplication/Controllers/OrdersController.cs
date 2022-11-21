using ChannelEngineShared.Models;
using ChannelEngineWebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace ChannelEngineWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        public async Task<IActionResult> InProgressTop5Products(OrderRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
