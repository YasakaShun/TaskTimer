using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TaskTimer.ViewModel
{
    /// <summary>
    /// 各項目を表すクラス。
    /// </summary>
    public class Item : INotifyPropertyChanged
    {
        /// <summary>
        /// 文字列から生成
        /// </summary>
        static public Item Parse(string aStr)
        {
            var str = aStr.Split(',');
            return new Item
            {
                Name = str[0],
                Cycle = TimeSpan.FromDays(int.Parse(str[1])),
                Comment = str[2],
                DoneDate = DateTime.Parse(str[3]),
                Offset = TimeSpan.FromDays(int.Parse(str[4])),
            };
        }

        // コンストラクタ
        public Item()
        {
            mName = "No Name";
            mCycle = new TimeSpan(1, 0, 0, 0);
            mComment = "";

            DoneDate = DateTime.Today;
            Offset = new TimeSpan();
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
                OnPropertyChanged(nameof(Rest));
            }
        }
        private TimeSpan mCycle;

        // 残り時間
        public TimeSpan Rest
        {
            get
            {
                mRest = Cycle - (DateTime.Now - DoneDate) - Offset;
                return mRest;
            }
            set
            {
                mRest = value;
                Offset = Cycle - (DateTime.Now - DoneDate) - value;
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

        // 最後にやった日
        public DateTime DoneDate
        {
            get
            {
                return mDoneDate;
            }
            set
            {
                mDoneDate = value;
                OnPropertyChanged(nameof(DoneDate));
            }
        }
        private DateTime mDoneDate;

        public TimeSpan Offset
        {
            get
            {
                return mOffset;
            }
            set
            {
                mOffset = value;
                OnPropertyChanged(nameof(Offset));
                OnPropertyChanged(nameof(Rest));
            }
        }
        private TimeSpan mOffset;

        /// <summary>
        /// やった
        /// </summary>
        public void Done()
        {
            DoneDate = DateTime.Now;
            Offset = new TimeSpan();
            MessageBox.Show("えらい！");
        }

        /// <summary>
        /// 文字列として出力
        /// </summary>
        public override string ToString()
        {
            return
                Name + "," +
                Cycle.Days.ToString() + "," +
                Comment + "," +
                DoneDate.ToString() + "," +
                Offset.Days.ToString()
                ;
        }

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
}
