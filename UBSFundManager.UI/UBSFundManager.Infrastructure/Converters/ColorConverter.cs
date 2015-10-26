using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using UBSFundsManager.DTOs;

namespace UBSFundManager.Infrastructure.Converters
{
   public class ColorMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values != null)
            {
                if (values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue && values[2] != DependencyProperty.UnsetValue)
                {
                    var stockType = values[0].ToString().Trim();
                    var mktVal = decimal.Parse(values[1].ToString());
                    var tranCost = decimal.Parse(values[2].ToString());
                    if (mktVal < 0 || (stockType == Constants.StockType.Equity && tranCost > 100000) || (stockType == Constants.StockType.Bond && tranCost > 200000))
                    {
                        return new SolidColorBrush(Colors.Red);
                    }
                }
                else
                    new SolidColorBrush(Colors.White);
            }
           return  new SolidColorBrush(Colors.White);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
