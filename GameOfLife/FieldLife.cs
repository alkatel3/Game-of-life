using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class FieldlLife
    {
        public Field field;

        public FieldlLife(string path)
        {
            field = new Field();
            field.FillData(path);
            field.SetArrayDimensions();
            field.SetGeneration();
            field.FillingField();
        }
        public void FullLife()
        {
            for (int i = 0; i < field.Generation; i++)
            {
                LifeOfOneGeneration();
            }
        }
        public void LifeOfOneGeneration()
        {
            int Neighbors;
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Weight; j++)
                {
                    Neighbors = FindNeighbors(i, j);
                    if (Neighbors == 3 && !field.field[i, j].CurrentValue)
                    {
                        field.field[i, j].SwitchValue();
                    }
                    if (field.field[i, j].CurrentValue)
                    {
                        if (Neighbors == 2 || Neighbors == 3)
                        {
                            continue;
                        }
                        else
                        {
                            field.field[i, j].SwitchValue();
                        }
                    }
                }
            }
            SwitchCurrentValue();
        }
        public void SwitchCurrentValue()
        {
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Weight; j++)
                {
                    field.field[i, j].ChangeCurrentValueToNextValue();
                }
            }
        }
        public int FindNeighbors(int index1, int index2)
        {
            int Neighbors = 0;
            if (field.GetByIndexs(index1 + 1, index2 + 1))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1 + 1, index2))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1 + 1, index2 - 1))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1, index2 - 1))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1 - 1, index2 - 1))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1 - 1, index2))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1 - 1, index2 + 1))
            {
                Neighbors++;
            }
            if (field.GetByIndexs(index1, index2 + 1))
            {
                Neighbors++;
            }
            return Neighbors;
        }
    }
}