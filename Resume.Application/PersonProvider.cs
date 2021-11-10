using Resume.Application.Interfaces;
using Resume.Domain;
using System.Net.Http.Json;

namespace Resume.Application;

public class PersonProvider : IPersonProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _personFilePath;

    public PersonProvider(HttpClient httpClient, string filePath)
    {
        _httpClient = httpClient;
        _personFilePath = filePath;
    }

    public async Task<Person?> GetAsync(CancellationToken cancellationToken = default)
    {
        var person = await _httpClient.GetFromJsonAsync<Person>(_personFilePath, cancellationToken);
        return person;
    }
}