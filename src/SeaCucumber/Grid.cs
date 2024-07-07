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
    
    public Cell[,] Value { get; private set; }

    public bool MoveEastFacing()
    {
        var moved = false;
        var newGrid = this.CreateGridClone();

        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                if (this.Value[i, j].Value != Cell.EastFacing)
                {
                    continue;
                }

                var nextJ = (j + 1) % this.columns;
                if (this.Value[i, nextJ].Value != Cell.Empty)
                {
                    continue;
                }

                newGrid[i, j].SetEmpty();
                newGrid[i, nextJ].SetEastFacing();
                moved = true;
            }
        }

        this.Value = newGrid;
        return moved;
    }

    public bool MoveSouthFacing()
    {
        var moved = false;
        var newGrid = this.CreateGridClone();

        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                if (this.Value[i, j].Value != Cell.SouthFacing)
                {
                    continue;
                }

                var nextI = (i + 1) % this.rows;
                if (this.Value[nextI, j].Value != Cell.Empty)
                {
                    continue;
                }

                newGrid[i,j].SetEmpty();
                newGrid[nextI, j].SetSouthFacing();
                moved = true;
            }
        }
        
        this.Value = newGrid;
        return moved;
    }

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

    private Cell[,] CreateGridClone()
    {
        var newGrid = new Cell[this.rows, this.columns];
        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                newGrid[i, j] = new Cell(this.Value[i, j].Value);
            }
        }
        return newGrid;
    }
}