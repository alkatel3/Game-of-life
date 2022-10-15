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
            using(StreamReader reader = new StreamReader(path))
            {
                data= reader.ReadToEnd();
            }
             Datas = data.Split("\n");
        }

        public void FillingField()
        {
            field = new Cell[Height, Weight];
            for(int i = 0; i < Height; i++)
            {
                for(int j =0; j < Weight; j++)
                {   
                    if(Datas[i + 2][j]=='.')
                    field[i,j] = new Cell(false);
                    else
                    {
                        field[i,j] = new Cell(true);
                    }
                }
            }
        }

        public void SetArrayDimensions()
        {
            Weight = Datas[2].Length-1;
            Height = Datas.Length - 2;
        }

        public void SetGeneration()
        {
            Int32.TryParse(Datas[0], out Generation);
        }

        public void ShowField()
        {
            for(int i=0; i < Height; i++)
            {
                for(int j=0; j < Weight; j++)
                {
                    if (field[i, j].Value)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
