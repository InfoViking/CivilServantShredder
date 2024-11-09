using System.Net.Http.Json;
using Adminbereich.Models;

namespace Adminbereich;

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
        client.Timeout = TimeSpan.FromSeconds(60);
        client.BaseAddress = new Uri(ApiUrl);
        return client;
    }

    public async Task<IEnumerable<T>> GetAsync<T>(CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        var result = await client.GetAsync(GetUrlEndpoint(typeof(T)), cancellationToken).ConfigureAwait(false);
        result.EnsureSuccessStatusCode();
        var obj = await result.Content.ReadFromJsonAsync(typeof(T[]), cancellationToken).ConfigureAwait(false);
        return obj as T[] ?? [];
    }

    public async Task<T> GetAsync<T>(Guid id, CancellationToken cancellationToken) where T : class
    {
        using var client = GetHttpClient();
        var result = await client.GetAsync(GetUrlEndpoint(typeof(T)) + $"/{id}", cancellationToken).ConfigureAwait(false);
        result.EnsureSuccessStatusCode();
        var obj = await result.Content.ReadFromJsonAsync(typeof(T), cancellationToken).ConfigureAwait(false);
        return obj as T ?? throw new ArgumentOutOfRangeException(nameof(id), id, "Kein Objekt mit angegebener ID gefunden");
    }

    public async Task PostAsync<T>(T obj, CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        await client.PostAsJsonAsync(GetUrlEndpoint(typeof(T)), obj, cancellationToken).ConfigureAwait(false);
    }

    public async Task PutAsync<T>(T obj, CancellationToken cancellationToken)
    {
        using var client = GetHttpClient();
        await client.PutAsJsonAsync(GetUrlEndpoint(typeof(T)), obj, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync<T>(Guid id, CancellationToken cancellationToken) where T : class
    {
        using var client = GetHttpClient();
        await client.DeleteAsync(GetUrlEndpoint(typeof(T)) + $"/{id}", cancellationToken).ConfigureAwait(false);
    }

    private static string GetUrlEndpoint(Type type)
    {
        var dictEndpoints = new Dictionary<Type, string>
        {
            {typeof(BP_TextOnly), nameof(BP_TextOnly).ToLower()},
            {typeof(BP_TextAndPicture), nameof(BP_TextAndPicture).ToLower()},
            {typeof(BP_Poll), nameof(BP_Poll).ToLower()},
        };

        if (!dictEndpoints.TryGetValue(type, out var endpoint))
            throw new ArgumentException($"The type {type} is not supported");

        return endpoint;
    }
}