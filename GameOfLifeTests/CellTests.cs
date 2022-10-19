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
        Cell Cell = new Cell(true);

        [TestMethod()]
        public void CellTest()
        {
            Assert.IsTrue(Cell.CurrentValue);
        }

        [TestMethod()]
        public void SwitchValueTest()
        {
            Cell.SwitchValue();

            Assert.IsFalse(Cell.NextValue);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Cell TestCell = new Cell(false);
            Assert.IsFalse(Cell.Equals(TestCell));
        }

        [TestMethod()]
        public void ChangeCurrentValueToNextValueTest()
        {
            Cell.SwitchValue();
            Cell.ChangeCurrentValueToNextValue();
            Assert.IsFalse(Cell.CurrentValue);
        }
    }
}