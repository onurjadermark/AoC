using System.Net;

namespace Solutions.Infrastructure;

public class AocHttpClient : IDisposable
{
    private const string BaseUri = "https://adventofcode.com";
    private readonly HttpClient _httpClient;
    private readonly string? _sessionCookie;
    private readonly int _year;
    private readonly int _day;

    public AocHttpClient(int year, int day)
    {
        _sessionCookie = GetSessionCookie();
        _year = year;
        _day = day;

        CookieContainer cookieContainer = new();
        cookieContainer.Add(new Uri(BaseUri), new Cookie("session", _sessionCookie));

        HttpClientHandler httpClientHandler = new()
        {
            CookieContainer = cookieContainer,
        };

        _httpClient = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri($"{BaseUri}/{year}/")
        };
        
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("AoC/1.0 (github.com/onurjadermark/AoC by x@x.com)");
    }

    public async Task<ClientResponse> GetPuzzleInput()
    {
        if (IsFutureDate(_year, _day))
        {
            return new ClientResponse { ResponseType = ClientResponseType.NotYetAvailable, Content = "Cannot get input for future dates." };
        }

        if (string.IsNullOrEmpty(_sessionCookie))
        {
            return new ClientResponse { ResponseType = ClientResponseType.Failure, Content = "Session cookie not found." };
        }

        HttpResponseMessage response = await _httpClient.GetAsync($"day/{_day}/input");
        string content = await response.Content.ReadAsStringAsync();

        return new ClientResponse
        {
            ResponseType = response.IsSuccessStatusCode ? ClientResponseType.Success : ClientResponseType.Failure,
            Content = content
        };
    }

    private bool IsFutureDate(int year, int day)
    {
        var today = DateTime.Today;
        var requestedDate = new DateTime(year, 12, day);
        return requestedDate > today;
    }

    private static string? GetSessionCookie()
    {
        string solutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Solutions");
        string filePath = Path.Combine(solutionDirectory, "Infrastructure", "session-cookie.txt");

        if (!File.Exists(filePath))
        {
            return null;
        }

        return File.ReadAllText(filePath);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}

public class ClientResponse
{
    public ClientResponseType ResponseType { get; init; }
    public string Content { get; init; } = string.Empty;
}

public enum ClientResponseType
{
    Success,
    Failure,
    NotYetAvailable
}