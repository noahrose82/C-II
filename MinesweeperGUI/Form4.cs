using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form4 : Form
    {
        private BindingSource bs = new BindingSource();
        private List<GameStat> statList = new();
        private readonly string saveFile = "scores.json"; // File to store scores

        public Form4(string name, int score)
        {
            InitializeComponent();
            LoadScores(); // Load previous scores

            bs.DataSource = statList;
            dataGridView1.DataSource = bs;

            // Fix ID assignment
            int newId = statList.Any() ? statList.Max(s => s.Id) + 1 : 1;
            var gameStat = new GameStat(newId, name, score, TimeSpan.Zero, DateTime.Now);

            statList.Add(gameStat);
            SaveScores(); // Save updated list
            RefreshBinding();
        }

        // Sorting by Name A-Z
        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderBy(s => s.Name).ToList();
            RefreshBinding();
        }

        // Sorting by Name Z-A
        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Name).ToList();
            RefreshBinding();
        }

        // Sorting by Score High-Low
        private void hILOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Score).ToList();
            RefreshBinding();
        }

        // Sorting by Score Low-High
        private void lOWHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderBy(s => s.Score).ToList();
            RefreshBinding();
        }

        // Sorting by Date
        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Date).ToList();
            RefreshBinding();
        }

        // Save scores to JSON file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveScores();
            MessageBox.Show("Scores saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Load scores from JSON file
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadScores();
            RefreshBinding();
            MessageBox.Show("Scores loaded successfully!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Clear all scores
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all scores?", "Clear Scores", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                statList.Clear();
                SaveScores();
                RefreshBinding();
            }
        }

        // Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Save scores to JSON
        private void SaveScores()
        {
            try
            {
                string json = JsonSerializer.Serialize(statList);
                File.WriteAllText(saveFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving scores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error Details: {ex}");
            }
        }

        // Load scores from JSON
        private void LoadScores()
        {
            if (File.Exists(saveFile))
            {
                try
                {
                    string json = File.ReadAllText(saveFile);
                    statList = JsonSerializer.Deserialize<List<GameStat>>(json) ?? new List<GameStat>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading scores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error Details: {ex}");
                }
            }
        }

        // Refresh UI bindings
        private void RefreshBinding()
        {
            bs.DataSource = null;
            bs.DataSource = statList;
            bs.ResetBindings(false);
        }

        public record GameStat(int Id, string Name, int Score, TimeSpan GameTime, DateTime Date);
    }
}
