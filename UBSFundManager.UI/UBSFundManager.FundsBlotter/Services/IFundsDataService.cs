using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBSFundManager.FundsBlotter.Model;
using UBSFundsManager.DTOs;

namespace UBSFundManager.FundsBlotter.Services
{
   public interface IFundsDataService
    {
       IList<StockType> GetAllStockTypeDetails();
       IList<StockDetail> GetAllStocks(int userid);
       IList<StockSummary> GetFundsSummary(int userid);
       bool SaveStockDetails(int userid,int stockId, int SelectedStockTypeId, int quantity, decimal price);
       bool DeleteStockDetails(StockDetail stock);
       
    }
}
