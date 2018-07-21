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
        }

        public ItemCollection Items { get; set; }
    }

}
