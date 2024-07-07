namespace SeaCucumber;

public class Grid
{
    private readonly int rows;
    private readonly int columns;

    public Grid(string[] input)
    {
        this.rows = input.Length;
        this.columns = input[0].Length;
        this.Value = new Cell[this.rows, this.columns];
        this.ParseInput(input);
    }
    
    public Cell[,] Value { get; }

    private void ParseInput(string[] input)
    {
        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                this.Value[i, j] = new Cell(input[i][j]);
            }
        }
    }

    public bool MoveEastFacing()
    {
        var moved = false;
        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                var cell = this.Value[i, j];
                var destinationCell = this.Value[i, (j + 1) % this.columns];
                if (cell.Value != Cell.EastFacing || destinationCell.Value != Cell.Empty)
                {
                    continue;
                }

                cell.SetEmpty();
                destinationCell.SetEastFacing();
                moved = true;
                // skip the next row since it just moved, but only if i is the last row to avoid skipping the first row of the next iteration
                if (j < this.columns - 1)
                {
                    j++;
                }
            }
        }
        return moved;
    }

    public bool MoveSouthFacing()
    {
        var moved = false;
        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                var cell = this.Value[i, j];
                var destinationCell = this.Value[(i + 1) % this.rows, j];
                if (cell.Value != Cell.SouthFacing || destinationCell.Value != Cell.Empty)
                {
                    continue;
                }
                
                cell.SetEmpty();
                destinationCell.SetSouthFacing();
                moved = true;
                // skip the next row since it just moved, but only if i is the last row to avoid skipping the first row of the next iteration
                if (i < rows - 1)
                {
                    i++;
                }
            }
        }
        return moved;
    }
}