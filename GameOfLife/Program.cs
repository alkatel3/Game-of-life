namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            field.FillData("input.txt");
            field.SetGeneration();
            field.SetArrayDimensions();
            field.FillingField();
            field.ShowField();
        
        }
    }
}