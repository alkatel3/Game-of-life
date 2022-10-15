using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        public bool Value { get; private set; }

        public Cell(bool value)
        {
            Value = value;
        }

        public void SwitchValue()
        {
            Value = !Value;
        }
    }
}
