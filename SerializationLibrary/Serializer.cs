using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializationLibrary
{
    public class Serializer
    {
        public async Task SerializeAsync<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, obj);
            }
        }

        public async Task<T> DeserializeAsync<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }
    }
}
    