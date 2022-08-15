using Import.Models;

namespace Import
{
    public interface IFileOperations
    {
        public List<ProductDto> Read(string filePath);
    }
}
