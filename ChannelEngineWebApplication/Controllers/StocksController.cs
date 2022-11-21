using ChannelEngineShared.Models;
using ChannelEngineShared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        private readonly IMediator _mediator;

        public StocksController(IMediator mediator, ISharedManager manager)
        {
            _mediator = mediator;

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ActionName("UpdateStock")]
        public async Task<bool> UpdateStock(string productNo, int stock)

        {
            var request = new StockRequest() {MerchantProductNo =  productNo, StockValue = stock };
            var result = await _mediator.Send(request);
            return true;
        }
    }
}
