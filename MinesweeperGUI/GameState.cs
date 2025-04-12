using MineSweeperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinesweeperGUI
{
    [Serializable]
    public class GameState
    {
        public int GridSize { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] BoardState { get; set; } = null!; // Use null-forgiving operator to suppress warning

        [JsonPropertyName("boardState")]
        public List<int> FlatBoardState { get; set; }  // Flattened board state (1D list)

        public int Score { get; set; }
        public int SecondsElapsed { get; set; }

        // Constructor to initialize GameState with a 2D board state
        public GameState(int gridSize, float difficulty, int[,] boardState, int score, int secondsElapsed)
        {
            GridSize = gridSize;
            Difficulty = difficulty;
            Score = score;
            SecondsElapsed = secondsElapsed;

            FlatBoardState = new List<int>();
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    FlatBoardState.Add(boardState[r, c]);
                }
            }
        }

        // Constructor used for JSON deserialization
        [JsonConstructor]
        public GameState(int Score, int SecondsElapsed, int GridSize, string Difficulty)
        {
            this.Score = Score;
            this.SecondsElapsed = SecondsElapsed;
            this.GridSize = GridSize;
            this.Difficulty = float.Parse(Difficulty);
            FlatBoardState = new List<int>();
        }

        public GameState()
        {
            FlatBoardState = new List<int>();
        }

        // Convert the flat list back into a 2D array
        public int[,] GetBoardState()
        {
            int[,] boardState = new int[GridSize, GridSize];
            for (int i = 0; i < FlatBoardState.Count; i++)
            {
                int row = i / GridSize;
                int col = i % GridSize;
                boardState[row, col] = FlatBoardState[i];
            }
            return boardState;
        }
    }
}
