using Alor.OpenAPI.Utilities;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace Alor.OpenAPI.Websocket
{
    internal interface IWebSocketInfo : IDisposable
    {
        Func<IWebSocketInfo, Task>? Closed { get; set; }
        Func<IWebSocketInfo, Exception, Task>? Error { get; set; }
        Action<IWebSocketInfo, string>? Warning { get; set; }
        event Action<IWebSocketInfo, (byte[] data, int len, DateTime timestamp)> Message;
        WebSocketState State { get; }

        //GUID, Opcode
        ConcurrentDictionary<string, string> Opcodes { get; }
        bool IsConnected { get; }

        int ReconnectCount { get; set; }
        long ReceivedCount { get; }
        long ReceiveRate { get; }
        long SentCount { get; }
        long SentRate { get; }
        DateTime? LastUpdate { get; }

        int SocketId { get; }
        string Name { get; }

        Task StartAsync();
        Task<bool> SendAsync(string json);
        Task CloseSocketAndResetCounters();

        void CalculateReceiveRate();
        void CalculateSentRate();
        int? GetReaderCount();
        Action<AlorOpenApiLogLevel, string>? SendSocketStatus { get; set; }
    }
}
