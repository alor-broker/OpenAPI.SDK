using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    internal interface IWebSocketMessageHandler : IDisposable
    {
        public void UpdateWsOrderBookSimpleUserDelegate(Action<WsOrderBookSimple>? wsOrderBookChanged);
        public void UpdateWsOrderBookSlimUserDelegate(Action<WsOrderBookSlim>? wsOrderBookChanged);
        public void UpdateWsOrderBookHeavyUserDelegate(Action<WsOrderBookHeavy>? wsOrderBookChanged);
        public void UpdateWsCandleSimpleUserDelegate(Action<WsCandleSimple>? wsCandleChanged);
        public void UpdateWsCandleSlimUserDelegate(Action<WsCandleSlim>? wsCandleChanged);
        public void UpdateWsCandleHeavyUserDelegate(Action<WsCandleHeavy>? wsCandleChanged);
        public void UpdateWsSymbolSimpleUserDelegate(Action<WsSymbolSimple>? wsSymbolChanged);
        public void UpdateWsSymbolSlimUserDelegate(Action<WsSymbolSlim>? wsSymbolChanged);
        public void UpdateWsSymbolHeavyUserDelegate(Action<WsSymbolHeavy>? wsSymbolChanged);
        public void UpdateWsAllTradeSimpleUserDelegate(Action<WsAllTradeSimple>? wsAllTradeChangedFromUser);
        public void UpdateWsAllTradeSlimUserDelegate(Action<WsAllTradeSlim>? wsAllTradeChangedFromUser);
        public void UpdateWsAllTradeHeavyUserDelegate(Action<WsAllTradeHeavy>? wsAllTradeChangedFromUser);
        public void UpdateWsPositionSimpleUserDelegate(Action<WsPositionSimple>? wsPositionChangedFromUser);
        public void UpdateWsPositionSlimUserDelegate(Action<WsPositionSlim>? wsPositionChangedFromUser);
        public void UpdateWsPositionHeavyUserDelegate(Action<WsPositionHeavy>? wsPositionChangedFromUser);
        public void UpdateWsSummarySimpleUserDelegate(Action<WsSummarySimple>? wsSummaryChangedFromUser);
        public void UpdateWsSummarySlimUserDelegate(Action<WsSummarySlim>? wsSummaryChangedFromUser);
        public void UpdateWsSummaryHeavyUserDelegate(Action<WsSummaryHeavy>? wsSummaryChangedFromUser);
        public void UpdateWsRiskSimpleUserDelegate(Action<WsRiskSimple>? wsRiskChangedFromUser);
        public void UpdateWsRiskSlimUserDelegate(Action<WsRiskSlim>? wsRiskChangedFromUser);
        public void UpdateWsRiskHeavyUserDelegate(Action<WsRiskHeavy>? wsRiskChangedFromUser);
        public void UpdateWsFortsriskSimpleUserDelegate(Action<WsFortsriskSimple>? wsFortsriskChangedFromUser);
        public void UpdateWsFortsriskSlimUserDelegate(Action<WsFortsriskSlim>? wsFortsriskChangedFromUser);
        public void UpdateWsFortsriskHeavyUserDelegate(Action<WsFortsriskHeavy>? wsFortsriskChangedFromUser);
        public void UpdateWsTradeSimpleUserDelegate(Action<WsTradeSimple>? wsTradeChangedFromUser);
        public void UpdateWsTradeSlimUserDelegate(Action<WsTradeSlim>? wsTradeChangedFromUser);
        public void UpdateWsTradeHeavyUserDelegate(Action<WsTradeHeavy>? wsTradeChangedFromUser);
        public void UpdateWsOrderSimpleUserDelegate(Action<WsOrderSimple>? wsOrderChangedFromUser);
        public void UpdateWsOrderSlimUserDelegate(Action<WsOrderSlim>? wsOrderChangedFromUser);
        public void UpdateWsOrderHeavyUserDelegate(Action<WsOrderHeavy>? wsOrderChangedFromUser);
        public void UpdateWsSecurityFromWsSimpleUserDelegate(Action<WsSecurityFromWsSimple>? wsSecurityFromWsChangedFromUser);
        public void UpdateWsSecurityFromWsSlimUserDelegate(Action<WsSecurityFromWsSlim>? wsSecurityFromWsChangedFromUser);
        public void UpdateWsSecurityFromWsHeavyUserDelegate(Action<WsSecurityFromWsHeavy>? wsSecurityFromWsChangedFromUser);
        public void UpdateWsStopOrderSimpleUserDelegate(Action<WsStopOrderSimple>? wsStopOrderChangedFromUser);
        public void UpdateWsStopOrderSlimUserDelegate(Action<WsStopOrderSlim>? wsStopOrderChangedFromUser);
        public void UpdateWsStopOrderHeavyUserDelegate(Action<WsStopOrderHeavy>? wsStopOrderChangedFromUser);

        void MessageReceived((byte[] data, int len, DateTime timestamp) byteMsg, string socketName);

        void SetWsResponseMessageHandler(Action<WsResponseMessage>? handler);
        void SetWsResponseCommandMessageHandler(Action<WsResponseCommandMessage>? handler);
    }
}
