namespace Alor.OpenAPI.Websocket
{
    internal class WebSocketInfoDetails(string name, long sentCount, long receivedCount, DateTime? lastUpdate,
        int reconnectCount, long receiveRate, double recieveBufferCount, long sentRate)
    {
        internal readonly string Name = name;
        internal readonly long SentCount = sentCount;
        internal readonly long ReceivedCount = receivedCount;
        internal readonly DateTime? LastUpdate = lastUpdate;
        internal readonly int ReconnectCount = reconnectCount;
        internal readonly long SentRate = sentRate;
        internal readonly long ReceiveRate = receiveRate;
        internal readonly double RecieveBufferCount = recieveBufferCount;
    }
}
