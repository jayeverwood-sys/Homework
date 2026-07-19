using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HollowCreek
{
    public class SaveData
    {
        public string CurrentLocationName { get; set; }
        public int Unease { get; set; }
        public List<string> InventoryItemNames { get; set; } = new List<string>();
        public List<string> ReadDocumentNames { get; set; } = new List<string>();
    }

    public class Saveit
    {
        private const string SaveFilePath = "savegame.json";

        public void Save(PC player)
        {
            SaveData data = new SaveData();
            data.CurrentLocationName = player.GetCurrentLocationName();
            data.Unease = player.GetUnease();

            foreach (Items item in player.GetInventory().GetItems())
            {
                data.InventoryItemNames.Add(item.GetName());
            }
            foreach (foundDocuments document in player.GetInventory().GetJournal().GetReadDocuments())
            {
                data.ReadDocumentNames.Add(document.GetName());
            }
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFilePath, json);
        }

        public SaveData Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                return null;
            }

            string json = File.ReadAllText(SaveFilePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }

        public bool SaveExists()
        {
            return File.Exists(SaveFilePath);
        }
    }
}