using System;
using System.Windows;

namespace TaskTimer.AddWindow
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
            mAddViewModel = new AddViewModel();

            DataContext = mAddViewModel;
        }

        private ViewModel.Obj mViewModel;
        private AddViewModel mAddViewModel;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // 設定値をもとに追加
            var cycleTime = new TimeSpan(mAddViewModel.CycleDays, mAddViewModel.CycleHours, 0, 0);
            var restTime = new TimeSpan(mAddViewModel.RestDays, mAddViewModel.RestHours, 0, 0);
            if (mAddViewModel.RestSameAsCycle)
            {
                restTime = cycleTime;
            }

            var item = new ViewModel.Item
            {
                Name = mAddViewModel.Name,
                Cycle = cycleTime,
                Pass = cycleTime - restTime,
                Comment = mAddViewModel.Comment,
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
