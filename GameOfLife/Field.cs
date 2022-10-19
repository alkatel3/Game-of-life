using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Field
    {
        public Cell[,] field;
        public int Generation;
        public int Weight;
        public int Height;
        public string[] Datas;

        public void FillData(string path)
        {
            string data;
            using (StreamReader reader = new StreamReader(path))
            {
                data = reader.ReadToEnd();
            }
            Datas = data.Split("\n");
            for (int i = 0; i < Datas.Length; i++)
            {
                Datas[i] = Datas[i].Trim('\r');
            }
        }

        public bool GetByIndexs(int index1, int index2)
        {
            if (index1 < -1 || index1 > Height || index2 < -1 || index2 > Weight)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index1 == Height)
            {
                index1 = 0;
            }
            if (index1 == -1)
            {
                index1 = Height - 1;
            }
            if (index2 == Weight)
            {
                index2 = 0;
            }
            if (index2 == -1)
            {
                index2 = Weight - 1;
            }
            return field[index1, index2].CurrentValue;
        }

        public void FillingField()
        {
            if (Datas == null || Height == 0 || Weight == 0)
            {
                throw new InvalidOperationException();
            }
            field = new Cell[Height, Weight];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    if (Datas[i + 2][j] == '.')
                        field[i, j] = new Cell(false);
                    else
                    {
                        field[i, j] = new Cell(true);
                    }
                }
            }
        }

        public void SetArrayDimensions()
        {
            if (Datas == null)
            {
                throw new InvalidOperationException();
            }
            Weight = Datas[2].Length;
            Height = Datas.Length - 2;
        }

        public void SetGeneration()
        {
            if (Datas == null)
            {
                throw new InvalidOperationException();
            }
            Int32.TryParse(Datas[0], out Generation);
        }
    }
}
