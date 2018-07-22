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
            // 入力値が正しいかチェック
            if (string.IsNullOrEmpty(mAddViewModel.Name))
            {
                MessageBox.Show("項目名が入力されていません。\n項目名を入力してください。");
                return;
            }

            var cycleTime = new TimeSpan(mAddViewModel.CycleDays, mAddViewModel.CycleHours, 0, 0);
            var restTime = new TimeSpan(mAddViewModel.RestDays, mAddViewModel.RestHours, 0, 0);
            if (mAddViewModel.RestSameAsCycle)
            {
                restTime = cycleTime;
            }

            if (cycleTime.TotalHours <= 0)
            {
                MessageBox.Show("周期の入力が不正です。\n周期は1時間以上に設定してください。");
                return;
            }
            if (restTime.TotalHours < 0)
            {
                MessageBox.Show("次やるまでの時間の入力が不正です。\n0時間以上に設定してください。");
                return;
            }

            // 設定値をもとに追加
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
