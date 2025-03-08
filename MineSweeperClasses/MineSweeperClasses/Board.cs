using System;

namespace MineSweeperClasses
{
    public class Board
    {
        public int Size { get; private set; }
        public Cell[,] Cells { get; private set; }

        public enum GameStatus { Playing, Won, Lost }

        public Board(int size, float bombProbability)
        {
            Size = size;
            Cells = new Cell[size, size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cells[i, j] = new Cell();
                    if (rand.NextDouble() < bombProbability)
                        Cells[i, j].IsBomb = true;
                }
            }

            CalculateNeighborBombs();
        }

        private void CalculateNeighborBombs()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!Cells[i, j].IsBomb)
                    {
                        int count = 0;

                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                int ni = i + x, nj = j + y;
                                if (ni >= 0 && ni < Size && nj >= 0 && nj < Size && Cells[ni, nj].IsBomb)
                                    count++;
                            }
                        }

                        Cells[i, j].NumberOfBombNeighbors = count;
                    }
                }
            }
        }

        public void UseSpecialBonus(int row, int col)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int ni = row + x, nj = col + y;
                    if (ni >= 0 && ni < Size && nj >= 0 && nj < Size && !Cells[ni, nj].IsBomb)
                        Cells[ni, nj].IsVisited = true;
                }
            }
        }

        public GameStatus DetermineGameState()
        {
            foreach (var cell in Cells)
            {
                if (!cell.IsVisited && !cell.IsBomb)
                    return GameStatus.Playing;
            }
            return GameStatus.Won;
        }
    }
}
