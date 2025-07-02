using Alor.OpenAPI.DI;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Moq;

namespace Alor.OpenAPI.Tests;

public class HandlerSetTests
{
    [Fact]
    public void SetWsResponseMessageHandler_Proxies_To_Client()
    {
        var mock = new Mock<IAlorOpenApiClient>();
        var holder = new AlorOpenApiClientHolder();
        holder.SetClient(mock.Object);

        Action<WsResponseMessage> handler = msg => { };
        holder.SetWsResponseMessageHandler(handler);

        mock.Verify(x => x.SetWsResponseMessageHandler(handler), Times.Once);
    }
}