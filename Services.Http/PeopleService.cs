using Services.Interfaces;
using Models;
using System.Net.Http.Json;

namespace Services.Http
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        public PeopleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //implement all methods from IPeopleService using httpClient
        public async Task<int> CreateAsync(Person entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/people", entity);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<Person>()).Id;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/people/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<Person>> GetBySearchString(string search)
        {
            var response = await _httpClient.GetAsync($"api/people/search/{search}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();
        }
        public async Task<IEnumerable<Person>> GetPeopleWithAddressAsync()
        {
            var response = await _httpClient.GetAsync("api/people/withaddress");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();
        }
        public async Task<IEnumerable<Person>> ReadAllAsync()
        {
            var response = await _httpClient.GetAsync("api/people");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();
        }
        public async Task<Person?> ReadAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/people/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Person>();
        }
        public async Task<bool> UpdateAsync(int id, Person entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/people/{id}", entity);
            return response.IsSuccessStatusCode;

        }
    }
}
