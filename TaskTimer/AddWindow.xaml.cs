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

            // メンバ設定
            mViewModel = aViewModel;
            Item = new ViewModel.Item
            {
                Name = "New Item",
                Comment = ""
            };

            DataContext = Item;
        }

        private ViewModel.Obj mViewModel;
        public ViewModel.Item Item { get; set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // 設定値をもとに追加
            var item = new ViewModel.Item
            {
                Name = Item.Name,
                Cycle = Item.Cycle,
                Rest = Item.Rest,
                Comment = Item.Comment,
            };

            mViewModel.Items.Add(item);

            // ウィンドウを閉じる
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // ウィンドウを閉じる
            this.Close();
        }
    }
}
