using ChannelEngineShared.Models;
using ChannelEngineShared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChannelEngineWebApplication.Pages.Components
{
    public class DefaultModel : ViewComponent
    {
        private readonly IMediator _mediator;

        public DefaultModel(IMediator mediator, ISharedManager manager)
        {
            _mediator = mediator;

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IViewComponentResult> InvokeAsync(StockRequest request)

        {
            request = new StockRequest();
            var result = await _mediator.Send(request);
            return View(result);
        }
    }
}
