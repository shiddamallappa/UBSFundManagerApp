using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using UBSFundManager.FundsBlotter.Services;
using UBSFundManager.FundsBlotter.ViewModel;
using UBSFundsManager.DTOs;
using System.Collections.Generic;
using UBSFundManager.Infrastructure.Events;

namespace UBSFundManagerApp.Tests
{
    [TestClass]
    public class BlotterViewModelTests
    {
        [TestMethod]
        public void BlotterViewModel_Loading()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            int userId = 1;
            Mock<IEventAggregator> mockEventAggtr = new Mock<IEventAggregator>();
            Mock<IFundsDataService> mockFundService = new Mock<IFundsDataService>();
            var mockStockUpdatedEventEvent = new Mock<StockUpdatedEvent>();
            var mockCancelStockSelectedEventEvent = new Mock<CancelStockSelectedEvent>();
            mockEventAggtr.Setup(e => e.GetEvent<StockUpdatedEvent>()).Returns(mockStockUpdatedEventEvent.Object);
            mockEventAggtr.Setup(e => e.GetEvent<CancelStockSelectedEvent>()).Returns(mockCancelStockSelectedEventEvent.Object);
            var stockobject = new StockDetail(){StockId=1,Type="Equity",Price=25,Quantity=10,StockName="Equity1"};
            mockFundService.Setup(t => t.GetAllStocks(userId)).Returns(new List<StockDetail>() {stockobject });
            var viewModel = new BlotterViewModel(mockFundService.Object, mockEventAggtr.Object);

            
            Assert.IsNotNull(viewModel.Stocks);
            Assert.IsTrue(viewModel.Stocks.Contains(stockobject));
            mockFundService.Verify(s => s.GetAllStocks(It.IsAny<int>()), Times.Once);
            mockEventAggtr.Verify(s => s.GetEvent<StockUpdatedEvent>(), Times.Once);
            mockEventAggtr.Verify(s => s.GetEvent<CancelStockSelectedEvent>(), Times.Once);
            factory.Verify();
            
        }
    }
}
