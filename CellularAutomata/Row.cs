using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata
{
    class Row
    {
        public byte[] CA;

        public Row(byte[] content)
        {
            CA = new byte[content.Length];
            CA = content;
        }
    }
}
