using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TaskTimer
{
    /// <summary>
    /// MainGraph.xaml の相互作用ロジック
    /// </summary>
    public partial class MainGraph : UserControl
    {
        public MainGraph()
        {
            InitializeComponent();
        }
    }

    public class TimeSpanToGraph : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeSpan))
            {
                return 0;
            }

            var timeSpan = (TimeSpan)value;
            return timeSpan.TotalHours * 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
