using ChannelEngineShared;
using ChannelEngineShared.Configuration;
using ChannelEngineShared.Models;
using ChannelEngineWebApplication.Models;
using MediatR;
using Microsoft.Extensions.Options;
using SharedLibrary;

namespace ChannelEngineWebApplication.Handlers
{
    public class OrdersHandler : IRequestHandler<OrderRequest, OrderResponse>
    {
        private readonly ISharedManager _manager;
        public OrdersHandler(ISharedManager manager)
        {
            _manager = manager;
        }
        public Task<OrderResponse> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            var orders = _manager.FetchAllInProcessOrders();
            var top5ProductsList = _manager.Top5ProductsSoldList(orders);
            return Task.FromResult(new OrderResponse { Orders = orders, Top5Products = top5ProductsList});
        }
    }
}
