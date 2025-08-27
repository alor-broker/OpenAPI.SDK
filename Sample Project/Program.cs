using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Utilities;
using System.Collections.Concurrent;

namespace Sample_Project
{
    public static class Program
    {
        private static readonly List<CustomQueue<OrderbookSimple>> OrderbookQueueList = [];
        private static readonly ConcurrentDictionary<int, CustomQueue<OrderbookSimple>> OrderbookQueuesDict = new();
        private static Timer? _timer;
        private static IAlorOpenApiClient? _api;

        private static void Dispose()
        {
            _api?.Dispose();
            _timer?.Dispose();
            foreach (var queue in OrderbookQueueList)
            {
                _ = queue.StopChannel();
            }
            OrderbookQueueList.Clear();
            OrderbookQueuesDict.Clear();
            Console.WriteLine("Произошло освобождение ресурсов");
        }

        private static async Task Main(string[] args)
        {
            await InitAsync();
            await Task.Delay(Timeout.Infinite);
        }

        private static async Task InitAsync()
        {
            Dispose();

            var refreshtoken = (await File.ReadAllTextAsync("../../tokens/tokenAlorDev.txt")).Replace("\n", "").Replace("\t", "").Replace(" ", "");

            _api = await AlorOpenApiClient.CreateAsync(Configuration.Dev, refreshtoken, AlorOpenApiLogLevel.Information, false, null, WsResponseMessageHandler, WsResponseCommandMessageHandler);

            var moexSecurities = (await _api.Instruments.MdV2SecuritiesGetSimpleAsync(exchange: Exchange.MOEX))
                .Select(x => x.Symbol).ToList();

            var socketsNames = new List<string> { "OB1", "OB2", "OB3", "OB4" };
            InitializeQueues(socketsNames.Count, moexSecurities);

            //создадим пул подключений только для получения маркетдаты (стаканов)
            var orderbooksWsPool = _api.CreateWsPool(socketsNames, "CWS", socketsNames.Count, AlorOpenApiLogLevel.Information, "CustomPool");

            //подписываемся на получение стаканов по нескольким инструментам
            var obSubsGuidsDict = await orderbooksWsPool.Subscriptions.OrderBookGetAndSubscribeSimpleAsync(UpdateAlorOrderbook, moexSecurities.Take(4), Exchange.MOEX);

            //контроль за размещением заявок осуществляем через встроенное в клиент соединение
            var positionsSubsGuid = await _api.WsPoolManager.Subscriptions.PositionsGetAndSubscribeV2SimpleAsync(UpdateAlorPosition, Exchange.MOEX, "D39004");

            SetDailyTimer();
        }

        private static void UpdateAlorOrderbook(WsOrderBookSimple obj)
        {
            //Асинхронные или ресурсоемкие операции лучше выполнять не в потоке обработчика входящих сообщений
            //Для примера при получении информации о стакане запишем объект в очередь, а обрабатывать сообщение
            //будем уже в отдельном потоке

            if (obj.Data == null) return;
            var ticker = obj.Extract()?.Code; //получаем название тикера из исходной подписки
            if (string.IsNullOrEmpty(ticker)) return;
            var queue = OrderbookQueuesDict[ticker.GetHashCode()]; //выбираем нужный буфер из пула очередей
            queue.WriteToQueue(obj.Data);
        }

        private static void ReadFromQueueOrderbook(OrderbookSimple ob)
        {
            Console.WriteLine(ob.ToString()); // для примера просто выводим содержимое стакана в консоль
        }

        private static void UpdateAlorPosition(WsPositionSimple obj)
        {
            var a = obj.Extract()?.ToJson();
            Console.WriteLine(obj.ToJson());
        }

        private static void WsResponseMessageHandler(WsResponseMessage obj)
        {
            Console.WriteLine(obj.ToString());
        }

        private static void WsResponseCommandMessageHandler(WsResponseCommandMessage obj)
        {
            Console.WriteLine(obj.ToString());
        }

        private static void SetDailyTimer()
        {
            var timerTime = new TimeSpan(6, 40, 0); //Для примера делаем ежедневный рестарт для обновления списка инструментов и переподписок в 6:40:00
            var timeToGo = CalculateTimeToNextRun(timerTime);

            _timer = new Timer(TimerCallback, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        private static TimeSpan CalculateTimeToNextRun(TimeSpan timerTime)
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var timeToGo = timerTime - currentTime;
            if (timeToGo < TimeSpan.Zero)
            {
                timeToGo = timeToGo.Add(new TimeSpan(24, 0, 0));
            }
            return timeToGo;
        }

        private static void TimerCallback(object? state)
        {
            Task.Run(async () =>
            {
                try
                {
                    await InitAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в TimerCallback: {ex.Message}");
                }
            });
        }

        private static void InitializeQueues(int count, IEnumerable<string?> tickers)
        {
            for (var i = 0; i < count; i++)
            {
                OrderbookQueueList.Add(new CustomQueue<OrderbookSimple>(ReadFromQueueOrderbook));
            }

            var j = 0;
            foreach (var ticker in tickers.Where(x => !string.IsNullOrEmpty(x)))
            {
                var hash = ticker!.GetHashCode();
                OrderbookQueuesDict.TryAdd(hash, OrderbookQueueList[j]);

                j++;
                if (j == count)
                    j = 0;
            }
        }
    }
}
