using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UBSFundManager.FundsBlotter.Services;
using UBSFundManager.Infrastructure.Events;
using UBSFundManager.Infrastructure.Utility;

namespace UBSFundManager.FundsBlotter.ViewModel
{
    public class SummaryViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IFundsDataService fundsDataService;
        private readonly int LoggedUserId;
        public SummaryViewModel(IFundsDataService fundsdataservice, IEventAggregator eventaggregator)
        {
            //This userId should be set to logged user id on authentication/Authorisation is complemted
            // Now UserId is assumed as from app.config file (i.e..due to LocalDB instance)
            this.LoggedUserId = UtilityMethods.GetDefaultLoggedUserIdFromConfig();

            if (fundsdataservice == null) throw new ArgumentNullException("fundsdataservice");
            if (eventaggregator == null) throw new ArgumentNullException("eventAggregator");
          
            this.eventAggregator = eventaggregator;
            this.fundsDataService = fundsdataservice;
            GetAllStocksSummary();
            this.eventAggregator.GetEvent<UpdateStockSummary>().Subscribe(GetAllStocksSummary);

          
        }

        private void GetAllStocksSummary(object param = null)
        {
            this.StockSummary = new ListCollectionView(this.fundsDataService.GetFundsSummary(this.LoggedUserId).ToList());
            this.OnPropertyChanged("StockSummary");
        }

        public ICollectionView StockSummary { get; set; }
    }
}
