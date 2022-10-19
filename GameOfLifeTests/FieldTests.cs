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
    public class FieldTests
    {
        string path = "Input.txt";
        private int Generation = 3;
        private int Weight = 8;
        private int Height = 5;
        private string[] array =
        {
            "........",
            "..x.....",
            "..x.....",
            "..x.....",
            "........"
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
        }

        [TestMethod()]
        public void FillDataTest()
        {
            Field field = new Field();
            field.FillData(path);
            Assert.AreEqual(Generation.ToString(), field.Datas[0]);
            Assert.AreEqual($"{Height} {Weight}", field.Datas[1]);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], field.Datas[i + 2]);
            }
        }

        [TestMethod()]
        public void SetGenerationTest()
        {
            Field field = new Field();
            field.FillData(path);
            field.SetGeneration();
            Assert.AreEqual(Generation, field.Generation);
        }

        [TestMethod()]
        public void ThrowingExceptionTest()
        {
            Field field = new Field();
            Assert.ThrowsException<InvalidOperationException>(() => field.SetGeneration());
            Assert.ThrowsException<InvalidOperationException>(() => field.SetArrayDimensions());
            Assert.ThrowsException<InvalidOperationException>(() => field.FillingField());
            field.FillData(path);
            Assert.ThrowsException<InvalidOperationException>(() => field.FillingField());
        }

        [TestMethod()]
        public void SetArrayDimensionsTest()
        {
            Field field = new Field();
            field.FillData(path);
            field.SetArrayDimensions();
            Assert.AreEqual(Weight, field.Weight);
            Assert.AreEqual(Height, field.Height);
        }

        [TestMethod()]
        public void FillingFieldTest()
        {
            Field field = new Field();
            field.FillData(path);
            field.SetArrayDimensions();
            field.FillingField();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    Assert.AreEqual(fieldArray[i, j], field.field[i, j]);
                }
            }
        }

        [TestMethod()]
        public void GetByIndexsTest()
        {
            Field field = new Field();
            field.FillData(path);
            field.SetArrayDimensions();
            field.FillingField();
            Assert.IsFalse(field.GetByIndexs(0, 0));
            Assert.IsFalse(field.GetByIndexs(-1, -1));
            Assert.IsFalse(field.GetByIndexs(Height, Weight));
            Assert.IsTrue(field.GetByIndexs(1, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => field.GetByIndexs(0, Weight + 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => field.GetByIndexs(-2, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => field.GetByIndexs(0, -2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => field.GetByIndexs(Height + 1, 0));
        }
    }
}