using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared
{
    public class MerchantOrderLineResponse
    {
        public string Gtin { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
    }
}
