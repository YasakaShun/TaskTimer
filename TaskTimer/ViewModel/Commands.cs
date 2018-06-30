using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace TaskTimer.ViewModel
{
    // コマンド群
    public class Commands
    {
        public Commands(ViewModel.Obj aViewModel)
        {
            mViewModel = aViewModel;

            AddCommand = new AddCommandImpl();
            FileLoadCommand = new FileLoadCommandImpl();
            FileSaveCommand = new FileSaveCommandImpl();
        }

        private Obj mViewModel;

        public ICommand AddCommand { get; private set; }
        public ICommand FileLoadCommand { get; private set; }
        public ICommand FileSaveCommand { get; private set; }
    }

    // ファイル読み込みのダイアログを開く
    class FileLoadCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "ファイルを開く";
            dialog.Filter = "全てのファイル(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                // TODO:

            }
            else
            {
                // TODO:

            }
        }
    }

    // ファイル保存のダイアログを開く
    class FileSaveCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "ファイルを保存";
            dialog.Filter = "テキストファイル|*.txt";
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                // TODO:

            }
            else
            {
                // TODO:

            }
        }
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

}
