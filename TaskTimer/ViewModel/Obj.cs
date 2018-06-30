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
            Commands = new Commands(this);
        }

        public ItemCollection Items { get; set; }
        public Commands Commands { get; set; }
    }

}
