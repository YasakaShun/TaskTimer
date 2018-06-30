using System;
using System.Windows.Input;

namespace TaskTimer.ViewModel
{
    // コマンド群
    public class Commands
    {
        public Commands(ViewModel.Obj aViewModel)
        {
            mViewModel = aViewModel;

            TestCommand = new TestCommandImpl();
        }

        private Obj mViewModel;

        public ICommand TestCommand { get; private set; }
    }

    // コマンドのテスト
    class TestCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Windows.MessageBox.Show("Test");
        }
    }

}
