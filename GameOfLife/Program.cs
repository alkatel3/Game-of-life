namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FieldlLife life = new FieldlLife("input.txt");
            life.FullLife();
            WriteResultToFile.WriteToFile(life.field, "output.txt");
        }
    }
}