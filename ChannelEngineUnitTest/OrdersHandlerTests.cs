using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ChannelEngineShared;
using ChannelEngineShared.Models;
using SharedLibrary;
using ChannelEngineWebApplication.Handlers;

namespace ChannelEngineUnitTest
{
    [TestClass]
    public class OrdersHandlerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            //incase we use automapper 
        }

        [TestMethod]
        public void When_Calling_Orders_Handler()
        {
            var request = new OrderRequest()
            {
                Status = "IN_PROGRESS",
                TopCount = 5
            };

            //TODO mock setup can be done in init method so it can be used across the board
            var serviceProvider = new Mock<IServiceProvider>();
            var mockSharedManager = new Mock<ISharedManager>();

            var ordersHandler = new OrdersHandler(mockSharedManager.Object);

            var results = ordersHandler.Handle(request, new System.Threading.CancellationToken());
            Assert.IsNotNull(results.Result, "then_handler_result_should_not_be_null");

        }
    }
}