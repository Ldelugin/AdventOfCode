namespace SeaCucumber;

public class Cell
{
    public const char Empty = '.';
    public const char EastFacing = '>';
    public const char SouthFacing = 'v';
    
    public Cell(char value)
    {
        this.Value = value;
    }
    
    public char Value { get; private set; }

    public void SetEmpty() => this.Value = Empty;
    public void SetEastFacing() => this.Value = EastFacing;
    public void SetSouthFacing() => this.Value = SouthFacing;
}