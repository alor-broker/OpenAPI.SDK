
# Alor OpenAPI SDK

## Описание

**Alor OpenAPI SDK** — это библиотека, написанная на .NET 8, реализующая все методы из спецификации [Swagger](https://alor.dev/rawdocs2/WarpOpenAPIv2.yml), за исключением методов со статусом `deprecated`. SDK упрощает взаимодействие с API, предоставляя удобный интерфейс для работы с различными ресурсами и методами.

## Основные возможности

- Полная реализация актуальных методов API Warp OpenAPI.
- Простая интеграция в .NET проекты (в том числе через DI).
- Поддержка работы с веб-сокетами для получения рыночных данных в реальном времени (включая торговлю).
- Готовые примеры использования для быстрого старта.
- Встроенные тесты для проверки корректности работы.

## Структура проекта

- **WarpOpenAPIv2.yml** — спецификация Swagger для генерации методов API.
- **Sample Project/** — пример использования SDK в реальном проекте.
- **Sample DI Project/** — пример интеграции SDK в реальном проекте через механизм DI.
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
using Alor.OpenAPI.Utilities;

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


## 🚀 Интеграция с Dependency Injection (.NET)

SDK поддерживает удобную регистрацию и асинхронную инициализацию клиентов через DI разными способами.

---

### 1. Регистрация одного клиента в коде

```csharp
using Alor.OpenAPI.DI;

var options = new OpenApiClientOptions
{
    RefreshToken = "your-refresh-token",
    Contour = "Prod"
};

services.AddOpenApiClient(options);
```
> Используй этот способ, если задаёшь параметры клиента вручную.

---

### 2. Регистрация одного клиента через конфиг

**appsettings.json**  
```json
"Alor": {
  "Contour": "Dev",
  "RefreshToken": "your-refresh-token"
}
```

**Program.cs**  
```csharp
services.AddOpenApiClient(builder.Configuration.GetSection("Alor"));
```
> Для работы с конфиг-секциями требуется установить NuGet:  
> **Microsoft.Extensions.Configuration.Binder**

```
dotnet add package Microsoft.Extensions.Configuration.Binder
```
> Это нужно для корректного маппинга секций конфига в объект `OpenApiClientOptions`.

---

### 3. Регистрация нескольких клиентов (multi-client, через конфиг)

**appsettings.json**  
```json
"AlorClients": {
  "Profile1": { "Contour": "Prod", "RefreshToken": "token-pf1" },
  "Profile2":    { "Contour": "Dev",  "RefreshToken": "token-pf2" }
}
```

**Program.cs**  
```csharp
var section = builder.Configuration.GetSection("AlorClients");
services.AddOpenApiClientsFromConfiguration(section);
```
> Все параметры берутся только из json, делегаты при таком подходе НЕ задаются.

---

### 4. Получение клиента по имени

```csharp
public class MyService
{
    public MyService(IOpenApiClientProvider provider)
    {
        var profileClient1 = provider.Get("Profile1");
        // ...
    }
}
```

---

### 5. Использование клиента в сервисах/контроллерах

```csharp
public class MyController : ControllerBase
{
    private readonly IAlorOpenApiClient _client;

    public MyController(IAlorOpenApiClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> GetInstruments()
    {
        var result = await _client.Instruments.MdV2SecuritiesGetSimpleAsync("MOEX");
        return Ok(result);
    }
}
```

---

### 6. Динамическая установка обработчиков (делегатов) событий websocket

> **Важно:** Делегаты нельзя передать через JSON или IConfiguration!  
> Если DI-клиент создаётся через конфиг, обработчики назначаются позже — например, в контроллере, сервисе или любом другом месте, где получаешь клиента через DI.

```csharp
public class MyService
{
    public MyService(IAlorOpenApiClient client)
    {
        // Назначаем обработчик в рантайме
        client.SetWsResponseMessageHandler(msg => Console.WriteLine($"WS: {msg}"));
        client.SetWsResponseCommandMessageHandler(cmd => Console.WriteLine($"CMD: {cmd}"));
    }
}
```
> Такой способ нужен, если требуется реагировать на сообщения WebSocket в бизнес-логике.  
> Это лучший подход для DI, так как делегаты — это исполняемый код, их невозможно описать в конфиге.

---

### 7. Регистрация нескольких клиентов вручную в коде (с любыми параметрами и делегатами)

```csharp
var profileOptions1 = new OpenApiClientOptions
{
    RefreshToken = "token-profile1",
    Contour = "Prod",
    WsResponseMessageHandler = msg => Console.WriteLine($"PF1: {msg}")
    // другие параметры...
};

var profileOptions2 = new OpenApiClientOptions
{
    RefreshToken = "token-profile2",
    Contour = "Dev",
    WsResponseCommandMessageHandler = cmd => Console.WriteLine($"PF2: {cmd}")
    // другие параметры...
};

services.AddOpenApiClient("Profile1", profileOptions1);
services.AddOpenApiClient("Profile2", profileOptions2);
```
> Такой способ позволяет задать любые runtime-параметры и делегаты для каждого клиента вручную.

---

### 📝 Примечания

- Клиент создаётся асинхронно “в фоне” (через HostedService), не блокируя запуск приложения.
- Несколько клиентов легко регистрируются и доступны по имени.
- Все DI-компоненты покрыты unit-тестами (`Alor.OpenAPI.Tests`).
- Если обработчики-делегаты нужны — назначай их прямо в месте получения клиента через DI.

---

## Полный пример c DI

Полный пример использования SDK в режиме DI доступен в папке `Sample DI Project`. Он включает:
- Настройку клиента всемии способами, рассмотренными выше и загрузку токенов.
- Создание контроллера, который работает с клиентами, зарегистрированными в контейнере DI разными способами.

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
