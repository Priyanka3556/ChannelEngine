using ChannelEngineShared;
using ChannelEngineShared.Models;
using ChannelEngineWebApplication.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedLibrary;

namespace ChannelEngine.UnitTests
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
        public void When_Calling_Authorization_Handler()
        {
            var request = new OrderRequest()
            {
                Status = "IN_PROGRESS",
                TopCount = 5
            };

            //TODO mock setup can be done in init method so it can be used across the board
            var serviceProvider = new Mock<IServiceProvider>();
            var mockSharedManager = new Mock<ISharedManager>();


            var mockPaymentWorkerFactory = new Mock<SharedManager>(serviceProvider.Object);

            var ordersHandler = new OrdersHandler(mockPaymentWorkerFactory.Object);

            var results = ordersHandler.Handle(request, new System.Threading.CancellationToken());
            Assert.IsNotNull(results.Result, "then_handler_result_should_not_be_null");

        }
    }
}