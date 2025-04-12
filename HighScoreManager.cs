internal class HighScoreManager
{
    public List<HighScoreEntry> LoadHighScores()
    {
        // Example implementation: Replace with actual logic to load high scores.  
        return new List<HighScoreEntry>
       {
           new HighScoreEntry { PlayerName = "Alice", Score = 100 },
           new HighScoreEntry { PlayerName = "Bob", Score = 80 },
           new HighScoreEntry { PlayerName = "Charlie", Score = 60 }
       };
    }
}

internal class HighScoreEntry
{
    public string PlayerName { get; set; }
    public int Score { get; set; }
}
