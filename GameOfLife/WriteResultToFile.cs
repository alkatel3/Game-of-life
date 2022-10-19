namespace GameOfLife
{
    public static class WriteResultToFile
    {
        public static void WriteToFile(Field field, string path)
        {
            Cell[,] Field = field.field;
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < field.Height; i++)
                {
                    for (int j = 0; j < field.Weight; j++)
                    {
                        if (Field[i, j].CurrentValue)
                        {
                            writer.Write('X');
                        }
                        else
                        {
                            writer.Write('.');
                        }
                    }
                    writer.Write('\n');
                }
            }
        }
    }
}
