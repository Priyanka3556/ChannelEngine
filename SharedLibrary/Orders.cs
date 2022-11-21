using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared
{
    public class Orders
    {
        public MerchantOrderResponse[] Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public bool Success { get; set; }
    }
}
