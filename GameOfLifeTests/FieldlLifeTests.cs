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
    public class FieldlLifeTests
    {
        private FieldlLife life;
        string path = "Input.txt";
        private int Generation = 3;
        private int Weight = 8;
        private int Height = 5;
        private string[] array =
        {
            "x......x",
            "..x.....",
            "..x.....",
            "..x.....",
            "x......x"
        };
        public Cell[,] fieldArray;

        [TestInitialize]
        public void Init()
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(Generation + "\n");
                writer.Write($"{Height} {Weight}\n");
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                    {
                        writer.Write(array[i]);
                    }
                    else
                    {
                        writer.Write(array[i] + "\n");
                    }
                }
            }
            fieldArray = new Cell[Height, Weight];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 'x')
                    {
                        fieldArray[i, j] = new Cell(true);
                    }
                    else
                    {
                        fieldArray[i, j] = new Cell(false);
                    }
                }
            }
            life = new FieldlLife("Input.txt");
        }

        [TestMethod()]
        public void FindNeighborsTest()
        {
            Assert.AreEqual(3, life.FindNeighbors(0, 1));
            Assert.AreEqual(3, life.FindNeighbors(2, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => life.FindNeighbors(0, Weight + 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => life.FindNeighbors(-2, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => life.FindNeighbors(0, -2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => life.FindNeighbors(Height + 1, 0));
        }

        [TestMethod()]
        public void SwitchCurrentValueTest()
        {
            life.field.field[0, 0].SwitchValue();
            life.field.field[Height - 1, Weight - 1].SwitchValue();
            life.field.field[2, 2].SwitchValue();
            life.SwitchCurrentValue();
            Assert.IsFalse(life.field.field[0, 0].CurrentValue);
            Assert.IsFalse(life.field.field[Height - 1, Weight - 1].CurrentValue);
            Assert.IsFalse(life.field.field[2, 2].CurrentValue);
        }

        [TestMethod()]
        public void LifeOfOneGenerationTest()
        {
            life.LifeOfOneGeneration();
            Assert.IsTrue(life.field.field[2, 1].CurrentValue);
            Assert.IsTrue(life.field.field[2, 2].CurrentValue);
            Assert.IsFalse(life.field.field[1, 2].CurrentValue);
            Assert.IsTrue(life.field.field[2, 3].CurrentValue);
            Assert.IsFalse(life.field.field[3, 2].CurrentValue);
        }

        [TestMethod()]
        public void FullLifeTest()
        {
            life.FullLife();
            Assert.IsFalse(life.field.field[2, 1].CurrentValue);
            Assert.IsFalse(life.field.field[2, 2].CurrentValue);
            Assert.IsFalse(life.field.field[1, 2].CurrentValue);
            Assert.IsFalse(life.field.field[2, 3].CurrentValue);
            Assert.IsFalse(life.field.field[3, 2].CurrentValue);
        }

        [TestMethod()]
        public void WriteToFileTest()
        {
            string data;
            life.FullLife();
            WriteResultToFile.WriteToFile(life.field, "output.txt");

            using (StreamReader reader = new StreamReader("output.txt"))
            {
                data = reader.ReadToEnd();
            }

            Assert.AreEqual(data, "........\nXX......\n........\nXX......\n........\n");
        }
    }
}