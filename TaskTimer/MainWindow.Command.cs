using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace TaskTimer
{
    // コマンド定義用クラス
    public partial class MainWindow
    {
        public static readonly RoutedUICommand FileLoad = new RoutedUICommand();
        public static readonly RoutedUICommand FileSave = new RoutedUICommand();
        public static readonly RoutedUICommand AddItem = new RoutedUICommand();
        public static readonly RoutedUICommand DoneItem = new RoutedUICommand();
        public static readonly RoutedUICommand CopyItem = new RoutedUICommand();
        public static readonly RoutedUICommand PasteItem = new RoutedUICommand();
        public static readonly RoutedUICommand DeleteItem = new RoutedUICommand();

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileLoad_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "ファイルを開く";
            dialog.Filter = "CSVファイル(*.csv)|*.csv";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (var sr = new System.IO.StreamReader(dialog.FileName, System.Text.Encoding.UTF8))
                    {
                        mViewModel.Items.Clear();

                        while (!sr.EndOfStream)
                        {
                            mViewModel.Items.Add(ViewModel.Item.Parse(sr.ReadLine()));
                        }
                    }
                }
                catch (SystemException exception)
                {
                    System.Windows.MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// ファイル保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileSave_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "ファイルを保存";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                catch (SystemException exception)
                {
                    System.Windows.MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// 空の項目を追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var itemCollection = e.Parameter as ViewModel.ItemCollection;

            itemCollection.Add(new ViewModel.Item());
        }

        /// <summary>
        /// 指定アイテムを消化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneItem_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var item = e.Parameter as ViewModel.Item;
            if (item != null)
            {
                item.Done();
            }
        }

        /// <summary>
        /// 選択項目をコピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyItem_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // TODO: 実装

        }

        /// <summary>
        /// コピーした項目を貼り付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteItem_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // TODO: 実装

        }

        /// <summary>
        /// 指定アイテムを削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem_Execute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var item = e.Parameter as ViewModel.Item;
            if (item != null)
            {
                System.Windows.MessageBox.Show($"delete item.\nName: {item.Name}");
                // item.Delete();
            }
            else
            {
                System.Windows.MessageBox.Show("delete item. item is null");
            }
        }
    }
}
