using System.Windows;

namespace TaskTimer
{
    /// <summary>
    /// AddWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(ViewModel.Obj aViewModel)
        {
            InitializeComponent();

            mViewModel = aViewModel;
            DataContext = mViewModel;
        }

        private ViewModel.Obj mViewModel;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 設定値をもとに追加
            var item = new ViewModel.Item
            {
                Name = "Add"
            };

            mViewModel.Items.Add(item);
        }
    }
}
