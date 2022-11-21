using ChannelEngineShared.Models;
using ChannelEngineShared;
using MediatR;

namespace ChannelEngineWebApplication.Handlers
{
    public class StocksHandler : IRequestHandler<StockRequest, bool>
    {
        private readonly ISharedManager _manager;
        public StocksHandler(ISharedManager manager)
        {
            _manager = manager;
        }
        public Task<bool> Handle(StockRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_manager.UpdateProductStock(request.MerchantProductNo, request.StockValue));
        }
    }
}
