using Alor.OpenAPI.Core;
using Moq;
using Serilog;

namespace Alor.OpenAPI.Tests
{
    public class ApiExceptionTests
    {
        [Fact]
        public void ApiException_LogsExceptionDetails()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var message = "Test exception message";
            var statusCode = 400;
            var response = "Test response";
            var headers = new Dictionary<string, IEnumerable<string>>();

            // Act
            _ = new ApiException(loggerMock.Object, message, statusCode, response, headers, null);

            // Assert
            loggerMock.Verify(l => l.Error(It.IsAny<string>(), It.IsAny<ApiException>()), Times.Once());
        }
    }
}