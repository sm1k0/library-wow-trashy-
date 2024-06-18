using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationLibrary1
{
    public static class Serializer
    {
        public static void Serialize<T>(T data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
