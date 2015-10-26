using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBSFundsManager.DTOs;

namespace UBSFundManager.Infrastructure.Events
{

    public class UpdateStockSummary : PubSubEvent<object>
    {
    }
    public class StockUpdatedEvent : PubSubEvent<object>
    {
    }

    public class StockSelectedEvent : PubSubEvent<StockDetail>
    {
    }
    public class CancelStockSelectedEvent : PubSubEvent<object>
    {
    }
}
