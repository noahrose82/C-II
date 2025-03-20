using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MineSweeperClasses;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        private Board board;
        private Button[,] buttons;
        private int gridSize;
        private float difficulty;
        private int secondsElapsed;
        private int score;
        private System.Windows.Forms.Timer gameTimer;  // Explicitly using System.Windows.Forms.Timer
        private Label timeLabel;
        private Label scoreLabel;
        private Dictionary<string, Image> tileImages;
        private Image hiddenTile = Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\hidden.png");
        private Image emptyTile = Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\empty.png");
        private Image bombTile = Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\bomb.png");
        private Image flagTile = Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\flag.png");
        private Image[] numberTiles;

        private void LoadImages()
        {
            tileImages = new Dictionary<string, Image>
            {
                { "hidden", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\hidden.png") },
                { "flag", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\flag.png") },
                { "bomb", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\bomb.png") },
                { "0", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\empty.png") },
                { "1", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\one.png") },
                { "2", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\two.png") },
                { "3", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\three.png") },
                { "4", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\four.png") },
                { "5", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\five.png") },
                { "6", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\six.png") },
                { "7", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\seven.png") },
                { "8", Image.FromFile(@"C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\MinesweeperGUI\bin\Debug\net8.0-windows\eight.png") }
            };
        }

        public Form1(int size, float bombProbability)
        {
            gridSize = size;
            difficulty = bombProbability;
            board = new Board(gridSize, difficulty);

            LoadImages(); // Ensure this is called before InitializeComponent
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.ClientSize = new Size(gridSize * 30, gridSize * 30 + 50);
            buttons = new Button[gridSize, gridSize];

            // Load numbered tiles (1-8)
            numberTiles = new Image[9];
            for (int i = 1; i <= 8; i++)
            {
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\one.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\two.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\three.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\four.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\five.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\six.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\seven.png");
                numberTiles[i] = Image.FromFile($"C:\\Users\\james\\source\\repos\\noahrose82\\C-II\\MineSweeperClasses\\MinesweeperGUI\\bin\\Debug\\net8.0-windows\\eight.png");

            }

            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    Button btn = new Button
                    {
                        Width = 30,
                        Height = 30,
                        Location = new Point(c * 30, r * 30),
                        Tag = new Point(r, c),
                        BackgroundImage = hiddenTile,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    btn.MouseDown += OnCellClick;
                    buttons[r, c] = btn;
                    Controls.Add(btn);
                }
            }

            // Add Restart Button
            Button restartButton = new Button
            {
                Text = "Restart",
                Location = new Point(10, gridSize * 30 + 10),
                Width = 80,
                Height = 30
            };
            restartButton.Click += RestartGame;
            Controls.Add(restartButton);
        }
        

        private void OnCellClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Point pos = (Point)btn.Tag;
            int r = pos.X, c = pos.Y;

            if (e.Button == MouseButtons.Right) // Right-click for flag F
            {
                board.Cells[r, c].IsFlagged = !board.Cells[r, c].IsFlagged;
                btn.Text = board.Cells[r, c].IsFlagged ? "F" : "";
                return;
            }

            if (board.Cells[r, c].IsBomb)
            {
                MessageBox.Show("Game Over! You hit a mine.");
                RevealAllCells();
                return;
            }

            board.FloodFill(r, c);
            UpdateBoard();

            if (board.DetermineGameState() == Board.GameStatus.Won)
            {
                MessageBox.Show("Congratulations! You won!");
                RevealAllCells();
            }
        }

        private void UpdateBoard()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    var cell = board.Cells[r, c];

                    if (cell.IsFlagged)
                    {
                        buttons[r, c].BackgroundImage = tileImages["flag"];
                        buttons[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                        continue;
                    }

                    if (cell.IsVisited)
                    {
                        buttons[r, c].Enabled = false;
                        if (cell.IsBomb)
                            buttons[r, c].BackgroundImage = tileImages["bomb"];
                        else
                            buttons[r, c].BackgroundImage = tileImages[cell.NumberOfBombNeighbors.ToString()];

                        buttons[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (cell.IsVisited)
                    {
                        buttons[r, c].Enabled = false;
                        if (cell.IsBomb)
                            buttons[r, c].BackgroundImage = tileImages["bomb"];
                        else
                            buttons[r, c].BackgroundImage = tileImages[cell.NumberOfBombNeighbors.ToString()];

                        buttons[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        private void RevealAllCells()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    var cell = board.Cells[r, c]; // Add this line to define 'cell'
                    buttons[r, c].Enabled = false;
                    if (cell.IsBomb)
                        buttons[r, c].BackgroundImage = tileImages["bomb"];
                    else
                        buttons[r, c].BackgroundImage = tileImages[cell.NumberOfBombNeighbors.ToString()];

                    buttons[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            Controls.Clear();
            board = new Board(gridSize, difficulty);
            InitializeGame();
        }
    }
}
