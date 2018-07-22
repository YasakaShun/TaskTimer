using System.Collections.ObjectModel;

namespace TaskTimer.ViewModel
{
    public class ItemCollection : ObservableCollection<Item>
    {
        public ItemCollection()
        {
            this.Add(new Item { Name = "Solt", Comment = "塩だよ", Cycle = System.TimeSpan.FromDays(2) });
            this.Add(new Item { Name = "Sugar", Comment = "砂糖だよ", Cycle = System.TimeSpan.FromDays(3) });
            this.Add(new Item { Name = "Soy Source", Comment = "豆の源だよ" });
        }
    }
}
