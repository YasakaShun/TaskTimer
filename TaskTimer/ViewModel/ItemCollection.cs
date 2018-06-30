using System.Collections.ObjectModel;

namespace TaskTimer.ViewModel
{
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
