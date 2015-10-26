using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSFundsManager.DTOs
{
    public class StockSummary
    {
        public Nullable<int> TypeId { get; set; }
        public string StockType { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalMarketValue { get; set; }
        public decimal TotalStockWeight { get; set; }
    }
}
