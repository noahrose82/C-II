using System;
using MineSweeperClasses;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Minesweeper!");

        int boardSize = 10;      // Default board size
        float difficulty = 0.15f; // 15% of cells contain bombs

        Board board = new Board(boardSize, difficulty);

        while (board.DetermineGameState() == Board.GameStatus.InProgress)
        {
            DisplayBoard(board);
            Console.Write("Enter row and column (e.g., 3 4): ");
            string input = Console.ReadLine();

            if (ProcessInput(input, board))
            {
                if (board.DetermineGameState() == Board.GameStatus.Lost)
                {
                    Console.Clear();
                    DisplayBoard(board, revealAll: true);
                    Console.WriteLine("💥 You hit a bomb! Game over.");
                    break;
                }
                else if (board.DetermineGameState() == Board.GameStatus.Won)
                {
                    Console.Clear();
                    DisplayBoard(board, revealAll: true);
                    Console.WriteLine("🎉 Congratulations! You won!");
                    break;
                }
            }
        }
    }

    static void DisplayBoard(Board board, bool revealAll = false)
    {
        Console.Clear();
        Console.WriteLine("Minesweeper Board:");

        for (int i = 0; i < board.Size; i++)
        {
            for (int j = 0; j < board.Size; j++)
            {
                Cell cell = board.Cells[i, j];

                if (revealAll || cell.IsVisited)
                {
                    if (cell.IsBomb)
                        Console.Write("💣 ");
                    else
                        Console.Write(cell.NumberOfBombNeighbors + " ");
                }
                else
                {
                    Console.Write("■ ");
                }
            }
            Console.WriteLine();
        }
    }
}
