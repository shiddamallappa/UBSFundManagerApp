using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UBSFundManager.FundsBlotter.ViewModel;

namespace UBSFundManager.FundsBlotter.Views
{
    /// <summary>
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : UserControl
    {
        private StockViewModel viewModel;
        public StockView(StockViewModel viewmodel)
        {
            InitializeComponent();
            this.viewModel = viewmodel;
            this.DataContext = this.viewModel;
        }
    }
}
