using System.Windows.Controls;

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

            mList = new ViewModel.ItemCollection();
            DataContext = mList;
        }

        private ViewModel.ItemCollection mList;
    }
}
