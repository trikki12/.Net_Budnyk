using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Core
{
    public static class NoteJsonStorage
    {
        public static void SaveToJson(List<Note> notes, string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(notes, options);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
            }
        }

        public static List<Note> LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Note>();
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();

                    List<Note> notes = JsonSerializer.Deserialize<List<Note>>(json);

                    if (notes == null)
                    {
                        return new List<Note>();
                    }

                    return notes;
                }
            }
            catch
            {
                return new List<Note>();
            }
        }
    }
}