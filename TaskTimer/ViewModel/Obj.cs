using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskTimer.ViewModel
{
    public class Obj
    {
        public Obj()
        {
            Items = new ItemCollection();
            TestCommand = new TestCommandImpl();
        }

        public ItemCollection Items { get; set; }

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
