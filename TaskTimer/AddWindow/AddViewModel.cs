using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimer.AddWindow
{
    class AddViewModel
    {
        public string Name { get; set; }
        public int CycleDays { get; set; }
        public int CycleHours { get; set; }
        public int RestDays { get; set; }
        public int RestHours { get; set; }
        public string Comment { get; set; }
    }
}
