using Newtonsoft.Json;
using System.Net;
using TinyEarth.Models;

namespace TinyEarth.Models
{
    public class PlanService
    {
        private readonly HttpClient _httpClient;

        public PlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PlayerData>> GetPlayersAsync()
        {
            var response = await _httpClient.GetAsync("/v1/players");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var wrapper = JsonConvert.DeserializeObject<PlayerResponse>(json);

            return wrapper?.Data ?? new List<PlayerData>();
        }

        public async Task<PlayerData?> SearchPlayerByNameAsync(string playerName)
        {
            var response = await _httpClient.GetAsync("/v1/players");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var wrapper = JsonConvert.DeserializeObject<PlayerResponse>(json);

            if (wrapper?.Data == null)
                return null;

            return wrapper.Data
                .FirstOrDefault(p => string.Equals(p.PlainName, playerName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
