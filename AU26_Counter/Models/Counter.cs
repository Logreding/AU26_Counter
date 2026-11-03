using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU26_Counter.Models
{
    class Counter
    {
        public string Filename { get; set; }
        public int CountValue { get; set; } = 0;

        public string Text { get; set; } = string.Empty;

        public void AddCount () { CountValue++; }
        public void DecreaseCount () { CountValue--; }
    }
}
