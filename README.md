
# Alor OpenAPI SDK

## Описание

**Alor OpenAPI SDK** — это библиотека, написанная на .NET 8, реализующая все методы из спецификации [Swagger](https://alor.dev/rawdocs2/WarpOpenAPIv2.yml), за исключением методов со статусом `deprecated`. SDK упрощает взаимодействие с API, предоставляя удобный интерфейс для работы с различными ресурсами и методами.

## Основные возможности

- Полная реализация актуальных методов API Warp OpenAPI.
- Простая интеграция в .NET проекты.
- Поддержка работы с веб-сокетами для получения рыночных данных в реальном времени (включая торговлю).
- Готовые примеры использования для быстрого старта.
- Встроенные тесты для проверки корректности работы.

## Структура проекта

- **WarpOpenAPIv2.yml** — спецификация Swagger для генерации методов API.
- **Sample Project/** — пример использования SDK в реальном проекте.
- **Alor.OpenAPI.Tests/** — модульные тесты, демонстрирующие корректность работы методов.

## Установка из репозитория

1. Убедитесь, что у вас установлен .NET SDK версии 8 или выше.
2. Клонируйте репозиторий или загрузите архив с исходным кодом.
3. Соберите проект с помощью команды:
   ```bash
   dotnet build "Alor OpenAPI SDK.sln"
   ```

## Установка через NuGet

SDK [доступен](https://www.nuget.org/packages/Alor.OpenAPI) в официальном NuGet-репозитории.

## Установка через .NET CLI
```bash
dotnet add package Alor.OpenAPI
```

## Установка через Package Manager Console в Visual Studio
```powershell
Install-Package Alor.OpenAPI
```

После установки библиотека будет доступна в вашем проекте, и вы сможете использовать все предоставляемые методы.
Для подключения добавьте в проект зависимость Alor.OpenAPI.

## Быстрый старт

Пример минимального кода для начала работы с SDK:

```csharp
using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models.Simple;

class Program
{
    static async Task Main(string[] args)
    {
        // Загрузка токена
        var token = await File.ReadAllTextAsync("../../tokens/tokenAlorDev.txt");

        // Создание клиента
        var client = await AlorOpenApiClient.CreateAsync(
            Configuration.Dev, 
            token, 
            AlorOpenApiLogLevel.Information
        );

        // Получение списка инструментов
        var instruments = await client.Instruments.MdV2SecuritiesGetSimpleAsync(exchange: Exchange.MOEX);
        Console.WriteLine($"Получено {instruments.Count()} инструментов.");

        // Подписка на данные стаканов
        var orderbookSubscriptions = await client.WsPoolManager.Subscriptions.OrderBookGetAndSubscribeSimpleAsync(
            data => Console.WriteLine($"Обновление стакана: {data}"),
            instruments.Take(5).Select(x=> x.Symbol),
            Exchange.MOEX
        );
    }
}
```

## Полный пример

Полный пример использования SDK доступен в папке `Sample Project`. Он включает:
- Настройку клиента и загрузку токенов.
- Создание пула соединений для работы с веб-сокетами.
- Подписку на обновления стаканов и позиций.
- Использование таймеров для автоматической переподписки.

## Тестирование

Для запуска тестов выполните команду:

```bash
dotnet test "Alor OpenAPI SDK.sln"
```

Все тесты находятся в папке `Alor.OpenAPI.Tests` и покрывают основные методы SDK.

## Документация API

Подробную документацию по API можно найти по [ссылке](https://alor.dev/docs/).

## Поддержка

Проект открыт для замечаний и предложений. Для получения поддержки по работе SDK создайте или дополните существующий Issue, в котором подробно опишите Ваш вопрос. 
