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
            AddCommand = new AddCommandImpl();
        }

        private Obj mViewModel;

        public ICommand TestCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
    }

    // 空のItemを追加
    class AddCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var itemCollection = parameter as ViewModel.ItemCollection;

            itemCollection.Add(
                new ViewModel.Item
                {
                    Name = "Add"
                }
            );
        }
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
