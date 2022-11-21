using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared
{
    public interface ISharedManager
    {
        public Orders FetchAllInProcessOrders(string status = "IN_PROGRESS");
        public List<MerchantOrderLineResponse> Top5ProductsSoldList(Orders ordersData, int topCount = 5);
        public bool UpdateProductStock(string merchantProductNo, int stockValue);
    }
}
