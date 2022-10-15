using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void SwitchValueTest()
        {
            var Cell = new Cell
            {
                Value = true
            };

            Cell.SwitchValue();

            Assert.IsFalse(Cell.Value);
        }
    }
}