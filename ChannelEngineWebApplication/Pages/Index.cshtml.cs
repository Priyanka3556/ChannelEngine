using ChannelEngineShared;
using ChannelEngineShared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChannelEngineWebApplication.Pages
{
    [ViewComponent(Name = "Orders")]
    public class IndexModel : ViewComponent
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator, ISharedManager manager)
        {
            _logger = logger;
            _mediator = mediator;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        public async Task<IViewComponentResult> InvokeAsync(OrderRequest request)

        {
            var req = new OrderRequest { Status = "IN_PROGRESS", TopCount = 5 };
            var result = await _mediator.Send(req);
            return View(result);
        }
    }
}