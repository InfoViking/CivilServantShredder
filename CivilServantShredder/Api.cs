using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace CivilServantShredder;

public class Api
{
    private const string ApiUrl = "https://tinysoftware.de/shredder/";

    public async Task<string> WeatherForecast()
    {
        try
        {
            using var client = GetHttpClient();
            var result = await client.GetAsync("weatherforecast").ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static HttpClient GetHttpClient()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(5);
        client.BaseAddress = new Uri(ApiUrl);
        return client;
    }

    private async Task<IEnumerable<T>> GetAsync<T>(CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        var result = await client.GetAsync(GetUrlEndpoint(typeof(T)), cancellationToken);
        result.EnsureSuccessStatusCode();
        var obj = await result.Content.ReadFromJsonAsync(typeof(T[]), cancellationToken).ConfigureAwait(false);
        return obj as T[] ?? [];
    }

    private async Task PostAsync<T>(IEnumerable<T> objs, CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        await client.PostAsJsonAsync(GetUrlEndpoint(typeof(T)), objs, cancellationToken).ConfigureAwait(false);
    }

    private async Task PutAsync<T>(IEnumerable<T> objs, CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        await client.PutAsJsonAsync(GetUrlEndpoint(typeof(T)), objs, cancellationToken).ConfigureAwait(false);
    }

    private static string GetUrlEndpoint(Type type)
    {
        return type switch
        {
            _ => throw new InvalidOperationException($"The type {type.FullName} is not supported."),
        };
    }
}