namespace SeaCucumber;

public class Grid
{
    private readonly int rows;
    private readonly int columns;
    private readonly Cell[,] grid;

    public Grid(string[] input)
    {
        this.rows = input.Length;
        this.columns = input[0].Length;
        this.grid = new Cell[this.rows, this.columns];
        this.ParseInput(input);
    }

    private void ParseInput(string[] input)
    {
        for (var i = 0; i < this.rows; i++)
        {
            for (var j = 0; j < this.columns; j++)
            {
                this.grid[i, j] = new Cell(input[i][j]);
            }
        }
    }
}