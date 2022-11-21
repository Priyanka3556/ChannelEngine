using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared.Models
{
    public class OrderResponse
    {
        public Orders? Orders { get; set; }
        public List<MerchantOrderLineResponse>? Top5Products { get; set; }
    }

}
