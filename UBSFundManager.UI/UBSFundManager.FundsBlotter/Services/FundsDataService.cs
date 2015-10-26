using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UBSFundManager.FundsBlotter.Data;
using UBSFundManager.FundsBlotter.Model;
using UBSFundsManager.DTOs;

namespace UBSFundManager.FundsBlotter.Services
{
    public class FundsDataService:IFundsDataService
    {

        public IList<StockDetail> GetAllStocks(int UserId)
        {
            var stocks = new List<StockDetail>();
            try 
	            {

                    using (var entityrepo = new UBSFundsDBEntities())
                    {
                        stocks = entityrepo.spGetAllFundsByUserId(UserId).Select(s => new StockDetail()
                        {
                            StockId = s.BlotterId,
                            StockName = s.StockName,
                            StockTypeId = s.StockTypeId??0,
                            Type = s.StockType,
                            MarketValue = s.MarketValue ?? 0.0M,
                            Price = s.Price ?? 0.0M,
                            Quantity = s.Quantity ?? 0,
                            StockWieght = s.StockWieght ?? 0.0M,
                            TransactionCost = s.TransactionCost ?? 0.0M,
                        }).ToList();
                    }
            
	            }
	            catch (Exception ex)
	            {
		
		            throw;
	            }
            return stocks;
        }

        public IList<StockSummary> GetFundsSummary(int UserId)
        {
            var summaries = new List<StockSummary>();
            try
            {
                using (var entityrepo = new UBSFundsDBEntities())
                {
                    summaries = entityrepo.spGetAllFundsSummary(UserId).Select(s => new StockSummary
                    {
                        StockType =s.StockType,
                        TotalMarketValue =s.TotalMarketValue??0.0M,
                        TotalQuantity =s.TotalQuantity??0,
                        TotalStockWeight =s.TotalStockWeight??0.0M,
                        TypeId =s.TypeId
                        
                    }).ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return summaries;
        }

        public bool SaveStockDetails(int userid ,int stockId, int SelectedStockTypeId, int quantity, decimal price)
        {
            try
            {
                using (var entityrepo = new UBSFundsDBEntities())
                {
                    using (var transaction = entityrepo.Database.BeginTransaction())
                    {
                        try
                        {
                            if (stockId > 0)
                            {
                                var currentItem = entityrepo.tblStocks.Find(stockId);
                                var selectedType = entityrepo.tblStockTypes.FirstOrDefault(s => s.Id == currentItem.StockType);
                                if (currentItem != null)
                                {
                                    currentItem.Price = price;
                                    currentItem.Quantity = quantity;
                                    currentItem.MarketValue = price * quantity;
                                    currentItem.TransactionCost = price * quantity * (selectedType.TransactionCharge ?? 0.0M);
                                    entityrepo.SaveChanges();
                                    var latestEditItem = entityrepo.tblStocks.Find(currentItem.Id);
                                    if (latestEditItem != null)
                                    {
                                        var totalMarketValue = entityrepo.tblStocks.Sum(s => s.MarketValue) ?? 1;
                                        latestEditItem.StockWieght = ((latestEditItem.MarketValue / totalMarketValue));
                                        entityrepo.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                var count = entityrepo.tblStocks.Count(s => s.StockType == SelectedStockTypeId);

                                var selectedType = entityrepo.tblStockTypes.FirstOrDefault(s => s.Id == SelectedStockTypeId);
                                var StockName = string.Format("{0}{1}", selectedType != null ? selectedType.StockType : "Error", (count + 1));

                                var dbstockobj = new tblStock()
                                {
                                    StockName = StockName,
                                    Price = price,
                                    UserId = userid,
                                    Quantity = quantity,
                                    StockType = selectedType.Id,
                                    MarketValue = price * quantity,
                                    TransactionCost = price * quantity * (selectedType.TransactionCharge ?? 0.0M)
                                };
                                entityrepo.tblStocks.Add(dbstockobj);
                                entityrepo.SaveChanges();
                                var latestEntryItem = entityrepo.tblStocks.Find(dbstockobj.Id);
                                if (latestEntryItem != null)
                                {
                                    var totalMarketValue = entityrepo.tblStocks.Sum(s => s.MarketValue) ?? 1;
                                    latestEntryItem.StockWieght = (latestEntryItem.MarketValue / (totalMarketValue!=0?totalMarketValue:1));
                                    entityrepo.SaveChanges();
                                }
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<StockType> GetAllStockTypeDetails()
        {
            var stocks = new List<StockType>();
            try
            {
                using (var entityrepo = new UBSFundsDBEntities())
                {
                    stocks = entityrepo.tblStockTypes.Select(s => new StockType()
                    {
                        Id =s.Id,
                        Type = s.StockType,
                        TransactionCharge =s.TransactionCharge
                    }).ToList();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return stocks;
        }



        public bool DeleteStockDetails(StockDetail stock)
        {
            try
            {
                using (var entityrepo = new UBSFundsDBEntities())
                {
                    var delStock = entityrepo.tblStocks.Find(stock.StockId);
                    if (stock != null)
                    {
                        entityrepo.tblStocks.Remove(delStock);
                        entityrepo.SaveChanges();
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
