using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSFundsManager.DTOs
{

    public class StockDetail
    {
        public int StockId { get; set; }

        public int StockTypeId { get; set; }

        public string Type { get; set; }

        public string StockName { get; set; }

        [Required(ErrorMessage = "Please enter valid Stock Quantity")]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter valid Stock Price")]
        [Range(0.0, double.MaxValue)]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal MarketValue { get; set; }

        public decimal TransactionCost { get; set; }

        public decimal StockWieght { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", StockName);
        }

    }
}
