namespace BlazingGoL.Models;

public class GameOfLife
{
    public int Width { get; }
    public int Height { get; }
    public Cell[,] Grid { get; private set;}

    public GameOfLife(int width, int height)
    {
        Width = width;
        Height = height;
        Grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Grid[x, y] = new Cell(x, y, false);
            }
        }
    }

    // Helper method to count live neighbors
    private int CountLiveNeighbors(int x, int y)
    {
        int liveNeighbors = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int neighborX = (x + i + Width) % Width;
                int neighborY = (y + j + Height) % Height;

                if (Grid[neighborX, neighborY].IsAlive)
                {
                    liveNeighbors++;
                }
            }
        }

        return liveNeighbors;
    }

    // Method to update the grid based on Game of Life rules
    public void Update()
    {
        Cell[,] newGrid = new Cell[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                int liveNeighbors = CountLiveNeighbors(x, y);
                bool isAlive = Grid[x, y].IsAlive;

                if (isAlive && (liveNeighbors < 2 || liveNeighbors > 3))
                {
                    isAlive = false;
                }
                else if (!isAlive && liveNeighbors == 3)
                {
                    isAlive = true;
                }

                newGrid[x, y] = new Cell(x, y, isAlive);
            }
        }

        Grid = newGrid;
    }
}
