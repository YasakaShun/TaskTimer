using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TaskTimer.ViewModel
{
    /// <summary>
    /// 各項目を表すクラス。
    /// </summary>
    public class Item : INotifyPropertyChanged
    {
        // コンストラクタ
        public Item()
        {
            mName = "No Name";
            mCycle = new TimeSpan(1, 0, 0, 0);
            mRest = mCycle.Subtract(new TimeSpan(6, 0, 0));
            mComment = "No Comment";
        }

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

        // 周期
        public TimeSpan Cycle
        {
            get
            {
                return mCycle;
            }
            set
            {
                mCycle = value;
                OnPropertyChanged(nameof(Cycle));
            }
        }
        private TimeSpan mCycle;

        // 残り時間
        public TimeSpan Rest
        {
            get
            {
                return mRest;
            }
            set
            {
                mRest = value;
                OnPropertyChanged(nameof(Rest));
            }
        }
        private TimeSpan mRest;

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
