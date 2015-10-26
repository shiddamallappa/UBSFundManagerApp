using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSFundsManager.DTOs
{
   public static class Constants
   {
       #region RegionNames

       public static class StockType
       {
           public const string Equity = "Equity";
           public const string Bond = "Bond";
       }

       public static class Regions
       {
           public const string STOCKENTRY = "EntryRegion";
           public const string FUNDSBLOTTER = "BlotterRegion";
           public const string FUNDSSUMMARY = "SummaryRegion";
       }

      #endregion
   }
}
