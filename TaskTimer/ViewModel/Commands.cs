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
            AddCommand = new AddCommandImpl();
            DoneCommand = new DoneCommandImpl();
            FileLoadCommand = new FileLoadCommandImpl(aViewModel);
            FileSaveCommand = new FileSaveCommandImpl(aViewModel);
        }

        public ICommand AddCommand { get; private set; }
        public ICommand DoneCommand { get; private set; }
        public ICommand FileLoadCommand { get; private set; }
        public ICommand FileSaveCommand { get; private set; }
    }

    // ファイル読み込みのダイアログを開く
    class FileLoadCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModel.Obj mViewModel;

        public FileLoadCommandImpl(ViewModel.Obj aViewModel)
        {
            mViewModel = aViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "ファイルを開く";
            dialog.Filter = "CSVファイル(*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var sr = new System.IO.StreamReader(dialog.FileName, System.Text.Encoding.UTF8))
                    {
                        mViewModel.Items.Clear();

                        while (!sr.EndOfStream)
                        {
                            mViewModel.Items.Add(Item.Parse(sr.ReadLine()));
                        }
                    }
                }
                catch (SystemException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }

    // ファイル保存のダイアログを開く
    class FileSaveCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModel.Obj mViewModel;

        public FileSaveCommandImpl(ViewModel.Obj aViewModel)
        {
            mViewModel = aViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "ファイルを保存";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var sw = new System.IO.StreamWriter(dialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        foreach (var item in mViewModel.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
                catch (SystemException e)
                {
                    MessageBox.Show(e.Message);
                }
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

            itemCollection.Add(new ViewModel.Item());
        }
    }

    // 項目を消化
    class DoneCommandImpl : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = parameter as Item;
            if (item != null)
            {
                item.Done();
            }
        }
    }

}
