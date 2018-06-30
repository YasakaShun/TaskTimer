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

            DataContext = aViewModel;
        }
    }
}
