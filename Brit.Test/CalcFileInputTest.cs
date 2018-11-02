using Brit.Service.Core;
using Brit.Service.Interfaces;
using Xunit;

namespace Brit.Test
{
    public class CalcFileInputTest
    {
        [Fact]
        public void ReadFileMissingFileNameReturnsException()
        {
            var calcFileInput = new FileInput();

            var result = calcFileInput.ReadFile(string.Empty);

            Assert.True(result.HasException);
            Assert.Equal(@"No file path value supplied", result.Exception);
        }

        [Fact]
        public void ReadFileMissingFileReturnsException()
        {
            var calcFileInput = new FileInput();

            var result = calcFileInput.ReadFile(@"C:\foo\bar\nofile.txt");

            Assert.True(result.HasException);
            Assert.Equal(@"File Path references non existent file", result.Exception);
        }

        [Fact]
        public void CalcFileInputBindsToICalcFileInput()
        {
            var calcFileInput = new FileInput();

            Assert.IsAssignableFrom<IFileInput>(calcFileInput);
        }
    }
}
