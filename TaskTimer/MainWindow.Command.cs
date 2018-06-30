using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TaskTimer
{
    // コマンド定義用クラス
    public partial class MainWindow
    {
        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("コマンドが実行されました");
        }
    }
}
