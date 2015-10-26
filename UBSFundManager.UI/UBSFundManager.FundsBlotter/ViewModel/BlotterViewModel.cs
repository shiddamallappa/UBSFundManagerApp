using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using UBSFundManager.FundsBlotter.Model;
using UBSFundManager.FundsBlotter.Services;
using UBSFundManager.Infrastructure.Events;
using UBSFundManager.Infrastructure.Utility;
using UBSFundsManager.DTOs;

namespace UBSFundManager.FundsBlotter.ViewModel
{
    public class BlotterViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IFundsDataService fundsDataService;
        private readonly int LoggedUserId;
        public BlotterViewModel(IFundsDataService fundsdataservice, IEventAggregator eventaggregator)
        {
            //This userId should be set to logged user id on authentication/Authorisation is complemted
            // Now UserId is assumed as from app.config file (i.e..due to LocalDB instance)
            this.LoggedUserId = UtilityMethods.GetDefaultLoggedUserIdFromConfig();

            if (fundsdataservice == null) throw new ArgumentNullException("fundsdataservice");
            if (eventaggregator == null) throw new ArgumentNullException("eventAggregator");
          
            this.eventAggregator = eventaggregator;
            this.fundsDataService = fundsdataservice;
            this.ConfirmationRequest = new InteractionRequest<IConfirmation>();
            GetAllStocksDetails();
            this.eventAggregator.GetEvent<StockUpdatedEvent>().Subscribe(GetAllStocksDetails);
            this.eventAggregator.GetEvent<CancelStockSelectedEvent>().Subscribe(CancelSelectedStock);
            CancelSelectedStock();
            this.DeleteStockCommand = new DelegateCommand<object>(this.DeleteSelectedStockDetails);
           
        }

        private void RaiseConfirmation(StockDetail delstock)
        {
            this.ConfirmationRequest.Raise(
                new Confirmation { Content = delstock, Title = "Please click OK to Delete?" },
                c =>
                {
                    if (c.Confirmed)
                    {
                        var _delstock = c.Content as StockDetail;
                        if (this.fundsDataService.DeleteStockDetails(_delstock))
                        {
                            this.eventAggregator.GetEvent<StockUpdatedEvent>().Publish(string.Empty);
                            this.eventAggregator.GetEvent<UpdateStockSummary>().Publish(default(object));
                            this.eventAggregator.GetEvent<CancelStockSelectedEvent>().Publish(default(object));
                        }
                    }
                }
                );
        }



        private void DeleteSelectedStockDetails(object param)
        {
            var delstock = param as StockDetail;
            if(delstock  != null)
            {
                this.RaiseConfirmation(delstock);
            }
        }

        private void GetAllStocksDetails(object param=null)
        {
            this.Stocks = new ListCollectionView(this.fundsDataService.GetAllStocks(this.LoggedUserId).ToList());
            this.OnPropertyChanged("Stocks");
        }

        private void CancelSelectedStock(object param = null)
        {
            this.SelectedStock = null;
        }

       public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }

        public ICommand DeleteStockCommand { get; private set; }

        private StockDetail _selected;
        public StockDetail SelectedStock
        {
            get
            {
                return this._selected;
            }
            set
            {
                this._selected = value;
                if (value != null)
                {
                    this.eventAggregator.GetEvent<StockSelectedEvent>().Publish(this._selected);
                }
                OnPropertyChanged("SelectedStock");
            }
        }

        public ICollectionView Stocks { get; set; }

    }
}
