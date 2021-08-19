using Resume.Application.Interfaces;
using Resume.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Resume.Application
{
    public class PersonProvider : IPersonProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _personFilePath;

        public PersonProvider(HttpClient httpClient, string filePath)
        {
            _httpClient = httpClient;
            _personFilePath = filePath;
        }

        public async Task<Person> GetAsync()
        {
            var person = await _httpClient.GetFromJsonAsync<Person>(_personFilePath);
            return person;
        }
    }
}