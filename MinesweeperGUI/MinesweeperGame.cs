using MineSweeperClasses;

public class MinesweeperGame
{
    public Board Board { get; private set; }
    private int safeRevealsLeft = 10; 

    public MinesweeperGame(int size, float difficulty)
    {
        Board = new Board(size, difficulty);
    }

    public MinesweeperGame()
    {
    }

    public Point? UseSafeReveal()
    {
        if (safeRevealsLeft <= 0)
            return null;

        for (int r = 0; r < Board.Size; r++)
        {
            for (int c = 0; c < Board.Size; c++)
            {
                var cell = Board.Cells[r, c];
                if (!cell.IsBomb && !cell.IsVisited && !cell.IsFlagged)
                {
                    Board.FloodFill(r, c);
                    safeRevealsLeft--;
                    return new Point(r, c);
                }
            }
        }

        return null;
    }
}

