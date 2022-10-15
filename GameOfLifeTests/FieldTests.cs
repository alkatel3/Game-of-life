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
        private int Generation=3;
        private int Weight=8;
        private int Height=5;
        private string[] array =
        {
            "........",
            "..x.....",
            "..x.....",
            "..x.....",
            "........"
        };

        [TestInitialize]
        public void Init()
        {
            using(StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(Generation+"\n");
                writer.Write($"{Height} {Weight}\n");
                for(int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                    {
                        writer.Write(array[i]);
                    }
                    else
                    {
                        writer.Write(array[i]+"\n");
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
            Assert.AreEqual($"{Height} {Weight}",field.Datas[1]);
            for(int i=0;i<array.Length; i++)
            {
                Assert.AreEqual(array[i], field.Datas[i + 2]);
            }
        }

        [TestMethod()]
        public void ShowFieldTest()
        {
            //Assert.Fail();
        }
    }
}