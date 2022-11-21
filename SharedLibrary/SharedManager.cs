using ChannelEngineShared;
using ChannelEngineShared.Configuration;
using ChannelEngineShared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SharedLibrary
{
    public class SharedManager : ISharedManager
    {
        private readonly ChannelEngineSharedConfigOptions configSettings;
        public SharedManager(IOptions<ChannelEngineSharedConfigOptions> settings)
        {
            configSettings = settings.Value;
        }
        public Orders FetchAllInProcessOrders(string status = "IN_PROGRESS")
        {
            try
            {
                var channelEngineOrders = new Orders();
                var client = new HttpClient();

                client.BaseAddress = new Uri(configSettings.BaseUrl);
                var response = client.GetAsync(
                               $"v2/orders?apikey={configSettings.ApiKey}&statuses={status}").Result;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //log error
                    //throw unauthorized excpetion
                }
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();

                    channelEngineOrders = JsonConvert.DeserializeObject<Orders>(content.Result);
                }
                //else
                //throw error;
                return channelEngineOrders;
                //await client.GetAsync(
                //               $"content/propsextracts?includes=propCode&offset={offset}&limit={limit}");
            }
            catch (Exception ex)
            {
                //log exception 
            }
            return null;
        }
        public List<MerchantOrderLineResponse> Top5ProductsSoldList(Orders ordersData, int topCount = 5)
        {
            try
            {
                var allproducts = ordersData.Content.SelectMany(s => s.Lines).ToList();
                //var response = allproducts.OrderByDescending(p => p.Quantity).Take(5).ToList();
                //TBD - What should be used a parameter to group the products or all products are unqiue in lines
                var response = allproducts.GroupBy(l => l.Description).Select(g => new MerchantOrderLineResponse
                {
                    ChannelProductNo = g.First().ChannelProductNo,
                    Quantity = g.Sum(x => x.Quantity),
                    Gtin = g.First().Gtin,
                    Description = g.Key,
                    MerchantProductNo = g.First().MerchantProductNo
                }).OrderByDescending(l => l.Quantity).ToList();

                return response.Any() && response.Count > 5 ? response.Take(5).ToList() : response;
            }
            catch (Exception ex)
            {
                //log exception 
                return null;
            }
        }
        public bool UpdateProductStock(string merchantProductNo, int stockValue)
        {
            try
            {
                var updateReq = new List<StockProviderRequest>();
                var stock = new StockProviderRequest
                {
                    MerchantProductNo = merchantProductNo,
                    StockLocations = new List<StockLocations>()
                };
                stock.StockLocations.Add(new StockLocations { Stock = stockValue, StockLocationId = 0 });
                updateReq.Add(stock);

                var client = new HttpClient();
                client.BaseAddress = new Uri(configSettings.BaseUrl);

                var reqContent = JsonConvert.SerializeObject(updateReq);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(updateReq), Encoding.UTF8, "application/json");

                var response = client.PutAsync(
                               $"v2/offer/stock?apikey={configSettings.ApiKey}", content).Result;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //log error
                    //throw unauthorized excpetion
                }
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                //else
                //throw error;
                return false;
            }
            catch (Exception ex)
            {
                //log exception 
            }
            return false;
        }
    }

}