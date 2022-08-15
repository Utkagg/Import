using Import.Models;
using System.Text.Json;

namespace Import
{
    public class JsonFileOperations : IFileOperations
    {
        public List<ProductDto> Read(string filePath)
        {
            StreamReader r = new StreamReader(filePath);
            var jsonString = JsonDocument.Parse(r.ReadToEnd());
            var jsonProductsString = jsonString.RootElement.GetProperty("products").ToString();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<ProductJson>>(jsonProductsString, options)
                .ConvertAll(x => new ProductDto
                {
                    Categories = string.Join(',', x.Categories ?? new List<string>()),
                    Name = x.Title,
                    Twitter = x.Twitter
                });

        }
    }
}
