using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared.Models
{
    public class OrderRequest : IRequest<OrderResponse>
    {
        public string Status { get; set; }
        public int TopCount { get; set; }
    }
}
