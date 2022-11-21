using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared
{
    public class MerchantOrderResponse
    {
        public int Id { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public decimal TotalInclVat { get; set; }
        public MerchantOrderLineResponse[] Lines { get; set; }
    }
}
