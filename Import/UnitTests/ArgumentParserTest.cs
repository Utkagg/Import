using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Import.UnitTests
{
    [TestClass]
    public class ArgumentParserTest
    {
        private readonly ArgumentParser _parser;
        private Mock<ArgumentParser> _mockParser;
        private Mock<YamlFileOperations> _mockFileOperations;
        public ArgumentParserTest(ArgumentParser parser)
        {
            _mockParser = new Mock<ArgumentParser>();
            _mockFileOperations=new Mock<YamlFileOperations>();
        }

        [TestMethod]
        [TestCategory("ReadYaml")]
        public async Task Given_FilePathHasYamlExtension_When_ParseArgumentIsCalled_Then_ReadIsCalledFromYamlFileOperationsClass()
        {
            var path = new string[] { "myData", "products/myData.yaml" };
            _mockParser.Setup(x => x.ParseArguments(It.IsAny<string[]>()));

            // Act
            _parser.ParseArguments(path);


            // Assert
            _mockFileOperations.Verify(x => x.Read(It.IsAny<string>()), Times.Once);
        }
    }
}
