using Alor.OpenAPI.DI;
using Alor.OpenAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sample_DI_Project.Controllers;

public class ClientsInfoController(
    IAlorOpenApiClient defaultClient,
    IEnumerable<NamedOpenApiClientHolder> namedClients,
    IOpenApiClientProvider provider)
    : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> AllWays()
    {
        var results = new List<object>();

        // Дефолтный клиент
        if (defaultClient is not NamedOpenApiClientHolder)
        {
            try
            {
                var r = await defaultClient.Instruments.MdV2SecuritiesGetSimpleAsync("MOEX");
                results.Add(new { From = "Default", Client = "Default", r.Count, FirstTickers = r.Take(5).Select(x => x.Symbol) });

                defaultClient.SetWsResponseCommandMessageHandler(msg =>
                {
                    Console.WriteLine($"[AlorDefault2] WS: {msg}");
                });

                //реальный вызов  делать не будем, потому что все подписки требуют валидного токена, а мы его не указывали,
                //но если бы он был, то в обработчике WsResponseCommandMessageHandler мы бы увидели, что вывод начинается с "[AlorDefault2] WS:"

                //await defaultClient.WsPoolManager.Subscriptions.OrderBookGetAndSubscribeSimpleAsync((_) => { },
                //    r.Select(x => x.Symbol),
                //    Exchange.MOEX);
            }
            catch (Exception ex)
            {
                results.Add(new { From = "Default", Client = "Default", Error = ex.Message });
            }
        }

        // Именованные клиенты через IEnumerable
        foreach (var c in namedClients)
        {
            try
            {
                var r = await c.Instruments.MdV2SecuritiesGetSimpleAsync("MOEX");
                results.Add(new { From = "Named", Client = c.Name, r.Count, FirstTickers = r.Take(5).Select(x => x.Symbol) });
            }
            catch (Exception ex)
            {
                results.Add(new { From = "Named", Client = c.Name, Error = ex.Message });
            }
        }

        // Получение по имени через Provider
        foreach (var c in namedClients)
        {
            try
            {
                var name = c.Name;
                var pc = provider.Get(name);
                var r = await pc.Instruments.MdV2SecuritiesGetSimpleAsync("MOEX");
                results.Add(new { From = "Provider", Client = c.Name, r.Count, FirstTickers = r.Take(5).Select(x => x.Symbol) });
            }
            catch (Exception ex)
            {
                results.Add(new { From = "Provider", Client = c.Name, Error = ex.Message });
            }
        }

        return Ok(results);
    }
}