using AutoMapper;
using Import.Models;
using YamlDotNet.Serialization.NamingConventions;

namespace Import
{
    public class YamlFileOperations : IFileOperations
    {
        public List<ProductDto> Read(string filePath)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
               .WithNamingConvention(LowerCaseNamingConvention.Instance)
       .Build();
            var products = deserializer.Deserialize<List<ProductYaml>>(File.ReadAllText(filePath));
            return products.ConvertAll(x => new ProductDto { Name = x.Name, Categories = x.Tags, Twitter = x.Twitter });

        }
    }
}
