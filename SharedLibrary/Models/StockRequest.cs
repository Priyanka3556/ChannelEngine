using MediatR;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared.Models
{
    public class StockRequest : IRequest<bool>
    {
        public string MerchantProductNo { get; set; }
        public int StockValue { get; set; }
    }
}
