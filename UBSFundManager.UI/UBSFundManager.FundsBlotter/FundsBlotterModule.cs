using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBSFundManager.FundsBlotter.Services;
using UBSFundManager.FundsBlotter.ViewModel;
using UBSFundManager.FundsBlotter.Views;
using UBSFundsManager.DTOs;

namespace UBSFundManager.FundsBlotter
{
    public class FundsBlotterModule:IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        public FundsBlotterModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.container.RegisterType<IFundsDataService, FundsDataService>();
            this.regionManager.RegisterViewWithRegion(Constants.Regions.FUNDSBLOTTER,
                                                      () => this.container.Resolve<BlotterView>());
            this.regionManager.RegisterViewWithRegion(Constants.Regions.STOCKENTRY,
                                                                () => this.container.Resolve<StockView>());

            this.regionManager.RegisterViewWithRegion(Constants.Regions.FUNDSSUMMARY,
                                                               () => this.container.Resolve<StockSummaryView>());
 
        }
    }
}
