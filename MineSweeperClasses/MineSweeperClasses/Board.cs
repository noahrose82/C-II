namespace MineSweeperClasses
{
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public enum GameStatus { InProgress, Won, Lost }

        private Random random = new Random();

        public Board(int size, float difficulty)
        {
            Size = size;
            Cells = new Cell[size, size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j] = new Cell();  // Ensure every cell is instantiated
                }
            }

            RewardsRemaining = 0;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j].NumberOfBombNeighbors = GetNumberOfBombNeighbors(i, j);
                }
            }
        }

        // Helper function to determine the number of bomb neighbors for a cell
        private int GetNumberOfBombNeighbors(int i, int j)
        {
            int count = 0;

            for (int d = 0; d < 8; d++)
            {
                int ni = i + dx[d];
                int nj = j + dy[d];

                if (IsCellOnBoard(ni, nj) && Cells[ni, nj].IsBomb)
                {
                    count++;
                }
            }
            return count;
        }
                }
            }
        }

        private void SetupRewards()
        {
            int totalRewards = (int)(Size * Size * 0.05); // Example: 5% of cells get rewards
            int placedRewards = 0;

            while (placedRewards < totalRewards)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);

                if (!Cells[row, col].IsBomb && !Cells[row, col].IsFlagged)
                {
                    RewardsRemaining++;
                    placedRewards++;
                }
            }
        }

        public GameStatus DetermineGameState()
        {
            foreach (var cell in Cells)
            {
                if (!cell.IsVisited && !cell.IsBomb)
                {
                    unrevealedCells++;
                }
            }
                return GameStatus.Won;
        }
    }
}
