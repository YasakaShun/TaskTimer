using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimer.ViewModel
{
    /// <summary>
    /// 各項目を表すクラス。
    /// </summary>
    public class Item : INotifyPropertyChanged
    {
        // 名前
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string mName;

        // public DateTimeOffset Cycle { get; set; }
        // public DateTimeOffset LestTime { get; set; }

        // コメント
        public string Comment
        {
            get
            {
                return mComment;
            }
            set
            {
                mComment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        private string mComment;

        // INotifyPropertyChanged インターフェースの実装
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string aPropertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(aPropertyName));
            }
        }
    }

    public class ItemCollection : ObservableCollection<Item>
    {
        public ItemCollection()
        {
            this.Add(new Item { Name = "Solt", Comment = "塩だよ" });
            this.Add(new Item { Name = "Sugar", Comment = "砂糖だよ" });
            this.Add(new Item { Name = "Soy Source", Comment = "豆の源だよ" });
        }
    }
}
