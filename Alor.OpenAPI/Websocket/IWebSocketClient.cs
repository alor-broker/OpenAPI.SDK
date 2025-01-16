using System.Net.WebSockets;

namespace Alor.OpenAPI.Websocket
{
    internal interface IWebSocketClient : IDisposable
    {
        WebSocketState State { get; }
        Task ConnectAsync(CancellationToken cancellationToken);
        Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken);
        Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);
        Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken);
    }
}
