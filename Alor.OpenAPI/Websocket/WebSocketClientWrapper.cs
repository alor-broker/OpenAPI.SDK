using System.Net;
using System.Net.WebSockets;

namespace Alor.OpenAPI.Websocket
{
    internal class WebSocketClientWrapper : IWebSocketClient
    {
        private readonly ClientWebSocket _webSocket;
        private readonly Uri _wsAddress;
        public WebSocketClientWrapper(Uri wsAddress, Dictionary<string, string>? wsHeaders = null)
        {
            _wsAddress = wsAddress;
            _webSocket = new ClientWebSocket()
                         {
                             Options =
                             {
                                 DangerousDeflateOptions = new WebSocketDeflateOptions
                                                           {
                                                               ClientMaxWindowBits = 10,
                                                               ServerMaxWindowBits = 10
                                                           },
                             }
                         };
            _webSocket.Options.SetBuffer(1024 * 1024 * 100, 1024 * 1024 * 10);
            _webSocket.Options.KeepAliveInterval = new TimeSpan(0, 0, 5);
            
            if (IPAddress.TryParse(wsAddress.Host, out _))
            {
                _webSocket.Options.RemoteCertificateValidationCallback = (sender, certificate, chain,
                    sslPolicyErrors) => true;
            }

            if (wsHeaders != null)
            {
                foreach (var header in wsHeaders)
                {
                    _webSocket.Options.SetRequestHeader(header.Key, header.Value);
                }
            }
        }

        public WebSocketState State => _webSocket.State;

        public Task ConnectAsync(CancellationToken cancellationToken) =>
            _webSocket.ConnectAsync(_wsAddress, cancellationToken);

        public Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage,
            CancellationToken cancellationToken) =>
            _webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);

        public Task<WebSocketReceiveResult>
            ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken) =>
            _webSocket.ReceiveAsync(buffer, cancellationToken);

        public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            CancellationToken cancellationToken) =>
            _webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);

        public void Dispose()
        {
            _webSocket.Dispose();
        }
    }
}
