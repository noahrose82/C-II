using System.IO;
using System.Text.Json;
namespace MinesweeperGUI
{
    [Serializable]
    public static class GameSaver
    {
        public static void SaveGame(GameState state, string filePath)
        {
            string json = JsonSerializer.Serialize(state);
            File.WriteAllText(filePath, json);
        }

        public static GameState? LoadGame(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<GameState>(json);
            }
            return null;
        }
    }
}
