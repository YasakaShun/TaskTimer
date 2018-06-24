using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskTimer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var windowsFormsHost = (WindowsFormsHost)MainGrid.Children[0];

            var chart = (Chart)windowsFormsHost.Child;

            // ChartArea追加
            {
                var area = new ChartArea("Area1");
                area.AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                area.Area3DStyle.Enable3D = true;
                chart.ChartAreas.Add(area);
            }

            // Seriesの作成と値の追加
            Series series = new Series();
            series.ChartType = SeriesChartType.Bar;

            for (int i = 0; i < 5; ++i)
            {
                series.Points.AddXY(i, 1 + i);
            }

            chart.Series.Add(series);
        }
    }
}
