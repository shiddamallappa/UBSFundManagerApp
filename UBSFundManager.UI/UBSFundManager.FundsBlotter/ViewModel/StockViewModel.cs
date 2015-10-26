using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBSFundManager.FundsBlotter.Model;
using UBSFundManager.FundsBlotter.Services;
using UBSFundManager.Infrastructure.Events;
using UBSFundManager.Infrastructure.Utility;
using UBSFundsManager.DTOs;

namespace UBSFundManager.FundsBlotter.ViewModel
{
    public class StockViewModel:BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IFundsDataService fundsDataService;
        private readonly int LoggedUserId;
        public StockViewModel(IFundsDataService fundsdataservice, IEventAggregator eventaggregator)
        {
            //This userId should be set to logged user id on authentication/Authorisation is complemted
            // Now UserId is assumed as from app.config file (i.e..due to LocalDB instance)
            this.LoggedUserId = UtilityMethods.GetDefaultLoggedUserIdFromConfig();

            if (fundsdataservice == null) throw new ArgumentNullException("fundsdataservice");
            if (eventaggregator == null) throw new ArgumentNullException("eventAggregator");
            this.NotificationRequest = new InteractionRequest<INotification>();
            validityMessage = string.Empty;
            this.eventAggregator = eventaggregator;
            this.fundsDataService = fundsdataservice;
            this.StockTypes = this.fundsDataService.GetAllStockTypeDetails();
            this.SaveStockDetailCommand = new DelegateCommand<object>(this.SaveStockDetails, this.CanSubmit);
            this.CancelStockDetailCommand = new DelegateCommand<object>(this.CancelStockDetails);
            this.eventAggregator.GetEvent<StockSelectedEvent>().Subscribe(BindSelectedStockDetails);
            ResetEntryValues();
            this.eventAggregator.GetEvent<CancelStockSelectedEvent>().Subscribe(ResetEntryValues);
            
        }

        private void BindSelectedStockDetails(StockDetail selectedstock)
        {
            var stock = selectedstock as StockDetail;
            if (stock != null)
            {
                SetEntryValuesforEdit(stock);
            }
        }

        private void SaveStockDetails(object parameter)
        {
            if (SelectedStockTypeId <= 0)
            {
                validityMessage += string.Format("{0}-Please Select Valid Stock Type.", Environment.NewLine);
            }

            if (Price <= 0)
            {
                validityMessage += string.Format("{0}-Please Enter Valid Price.", Environment.NewLine);
            }

            if (Quantity <= 0)
            {
                validityMessage += string.Format("{0}-Please Enter Valid Quantity.", Environment.NewLine);
            }
            if (!string.IsNullOrWhiteSpace(validityMessage))
            {
                validityMessage = string.Format("Please correct the the following,{0}", validityMessage);
                this.RaiseNotification();
            }
            else
            {
                int stockId = 0;
                int.TryParse(StockAction.Trim(), out stockId);
                if (this.fundsDataService.SaveStockDetails(this.LoggedUserId, stockId,SelectedStockTypeId, Quantity, Convert.ToDecimal(Price)))
                {
                    validityMessage = string.Format("Stock is added successfully.");
                    this.RaiseNotification(a =>
                    {
                        this.eventAggregator.GetEvent<StockUpdatedEvent>().Publish(string.Empty);
                        this.eventAggregator.GetEvent<UpdateStockSummary>().Publish(default(object));
                    });
                    ResetEntryValues();
                }
                else
                {
                    validityMessage = string.Format("Exception occured while adding Stock! Please contact Helpdesk.");
                    this.RaiseNotification();
                }

            }
        }

        
        public void CancelStockDetails(object parameter)
        {
            //ResetEntryValues();
            this.eventAggregator.GetEvent<CancelStockSelectedEvent>().Publish(default(object));
        }
        private void ResetEntryValues(object param=null)
        {
            StockAction = "New";
            Price = 0;
            Quantity = 0;
            SelectedStockTypeId = 0;
            IsSelectable = true ;
            this.OnPropertyChanged("IsSelectable");
            this.OnPropertyChanged("SelectedStockTypeId");
            this.OnPropertyChanged("Quantity");
            this.OnPropertyChanged("Price");
            this.OnPropertyChanged("StockAction");
        }
        private void SetEntryValuesforEdit(StockDetail stock)
        {
            StockAction = stock.StockId.ToString();
            Price = (float) stock.Price;
            Quantity = stock.Quantity;
            SelectedStockTypeId = stock.StockTypeId;
            IsSelectable = false;
            this.OnPropertyChanged("IsSelectable");
            this.OnPropertyChanged("SelectedStockTypeId");
            this.OnPropertyChanged("Quantity");
            this.OnPropertyChanged("Price");
            this.OnPropertyChanged("StockAction");
        }

        #region Inputs
        public int SelectedStockTypeId { get; set; }
        public bool IsSelectable { get; set; }

        //[Required(ErrorMessage = "Please enter valid Stock Quantity")]
        //[Range(0, int.MaxValue)]
        //[DefaultValue(0)]
        public int Quantity { get; set; }

        //[Required(ErrorMessage = "Please enter valid Stock Price")]
        //[Range(0.0, double.MaxValue)]
        //[DefaultValue(0)]
        //[DataType(DataType.Currency)]
        public float Price { get; set; }

        public string StockAction { get; set; }

        public StockDetail Details { get; set; }

        public IList<StockType> StockTypes { get; set; }

        #endregion

        public ICommand SaveStockDetailCommand { get; private set; }
        public ICommand CancelStockDetailCommand { get; private set; }


        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        private string validityMessage;
        public string ValidityMessage
        {
            get
            {
                return this.validityMessage;
            }
            set
            {
                this.validityMessage = value;
            }
        }
        private void RaiseNotification(Action<INotification> callback = null)
        {

            this.NotificationRequest.Raise(
               new Notification { Content = ValidityMessage, Title = "Stock Entry Message!" }, callback);
            validityMessage = string.Empty;
        }

        private bool CanSubmit(object parameter)
        {
            return true;
        }
    }
}
