using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared.Models
{
    public class StockProviderRequest : IRequest<bool>
    {
        public string MerchantProductNo { get; set; }
        public List<StockLocations> StockLocations { get; set; }
    }
    public class StockLocations
    {
        public int StockLocationId { get; set; }
        public int Stock { get; set; }
    }

}
