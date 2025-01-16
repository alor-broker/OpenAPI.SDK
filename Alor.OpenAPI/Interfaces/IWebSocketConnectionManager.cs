using Alor.OpenAPI.Websocket;

namespace Alor.OpenAPI.Interfaces
{
    internal interface IWebSocketConnectionManager : IDisposable
    {
        void JwtUpdate(string? newToken);
        bool AddToOpcodes(string guid, string message);
        bool TryToRemoveFromOpcodes(string guid);
        WebSocketInfoDetails GetSocketInfoDetails();
        void CalculateWebSocketInfoRecieveRate();
        void CalculateWebSocketInfoSentRate();
        Task<bool> SendOrStartAndSendCws(string message);
        Task<bool> SendOrStartAndSend(string message);
        Task<bool> SendOrStartAndSend(IReadOnlyCollection<string> messages);
    }
}
