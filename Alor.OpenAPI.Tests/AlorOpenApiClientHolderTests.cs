using Alor.OpenAPI.DI;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Moq;

namespace Alor.OpenAPI.Tests;

public class AlorOpenApiClientHolderTests
{
    [Fact]
    public void Throws_If_Not_Initialized()
    {
        var holder = new AlorOpenApiClientHolder();
        Assert.Throws<InvalidOperationException>(() => _ = holder.Instruments);
        Assert.Throws<InvalidOperationException>(() => holder.SetWsResponseMessageHandler(_ => { }));
    }

    [Fact]
    public void Proxies_Calls_To_Real_Client()
    {
        var mock = new Mock<IAlorOpenApiClient>();
        var holder = new AlorOpenApiClientHolder();
        holder.SetClient(mock.Object);

        // Прокси-свойства
        _ = holder.Instruments;
        mock.Verify(x => x.Instruments, Times.Once);

        // Прокси-методы
        holder.SetWsResponseMessageHandler(_ => { });
        mock.Verify(x => x.SetWsResponseMessageHandler(It.IsAny<Action<WsResponseMessage>>()), Times.Once);

        holder.Dispose();
        mock.Verify(x => x.Dispose(), Times.Once);
    }
}