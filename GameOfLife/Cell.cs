namespace GameOfLife
{
    public class Cell
    {
        public bool CurrentValue { get; private set; }
        public bool NextValue { get; private set; }


        public Cell(bool value)
        {
            CurrentValue = value;
            NextValue = value;
        }

        public void SwitchValue()
        {
            NextValue = !CurrentValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Cell cell)
            {
                return cell.CurrentValue == CurrentValue;
            }
            return false;
        }
        public void ChangeCurrentValueToNextValue()
        {
            CurrentValue = NextValue;
        }
    }
}