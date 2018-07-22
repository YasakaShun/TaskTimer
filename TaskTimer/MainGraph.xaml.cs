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

        /// <summary>
        /// DataGrid の選択行の内容をクリップボードにコピー。
        /// Ctrl + C での標準のコピーの内容を変更する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            e.ClipboardRowContent.Clear();
            e.ClipboardRowContent.Add(
                new DataGridClipboardCellContent(
                    e.Item,
                    (sender as DataGrid).Columns[0],
                    e.Item.ToString()
                    )
                );
        }
    }

    public class TimeSpanToWidth : IValueConverter
    {
        const double UnitWidth = 20.0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TimeSpan はnull許容型ではないので、asは使えない。
            if (!(value is TimeSpan))
            {
                return 0;
            }

            var timeSpan = (TimeSpan)value;
            bool isBorder = (bool)parameter;

            var retVal = timeSpan.TotalDays * UnitWidth;

            if (isBorder && timeSpan.TotalDays < 1)
            {
                retVal = timeSpan.TotalHours * UnitWidth / 24.0;
            }

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
