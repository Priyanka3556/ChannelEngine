using ChannelEngineShared;

namespace ChannelEngineWebApplication.Models
{
    public class OrderViewModel
    {
       public Orders? Orders { get; set; }
       public List<MerchantOrderLineResponse>? Top5Products { get; set; } 
    }
}
