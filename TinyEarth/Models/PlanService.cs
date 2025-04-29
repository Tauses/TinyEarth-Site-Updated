using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TinyEarth.Models
{
    public class PlanService
    {
        private readonly HttpClient _httpClient;
        private readonly string _planApiUrl = "http://plan.tiny-earth.com:25569/docs"; // skift denne

        public PlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // FETCH PLAYERNAME CONVERTS FROM UUID
        public async Task<Guid?> FetchUUIDOfAsync(string playerName)
        {
            var response = await _httpClient.GetAsync($"{_planApiUrl}/uuid/{playerName}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var uuid = JsonConvert.DeserializeObject<Guid>(content);
            return uuid;
        }

        // FETCH PLAYTIME BASED ON UUID
        public async Task<long> FetchPlaytimeAsync(Guid playerUUID, Guid serverUUID, long after, long before)
        {
            var response = await _httpClient.GetAsync($"{_planApiUrl}/playtime/{playerUUID}/{serverUUID}?after={after}&before={before}");
            if (!response.IsSuccessStatusCode) return 0;

            var content = await response.Content.ReadAsStringAsync();
            var playtime = JsonConvert.DeserializeObject<long>(content);
            return playtime;
        }

        // FETCH LAST SEEN BASED ON UUID
        public async Task<long> FetchLastSeenAsync(Guid playerUUID, Guid serverUUID)
        {
            var response = await _httpClient.GetAsync($"{_planApiUrl}/lastseen/{playerUUID}/{serverUUID}");
            if (!response.IsSuccessStatusCode) return 0;

            var content = await response.Content.ReadAsStringAsync();
            var lastSeen = JsonConvert.DeserializeObject<long>(content);
            return lastSeen;
        }

        // FETCH PLAYTIME BASED ON UUID
        public async Task<double> FetchActivityIndexAsync(Guid playerUUID, long epochMs)
        {
            var response = await _httpClient.GetAsync($"{_planApiUrl}/activityindex/{playerUUID}?epochMs={epochMs}");
            if (!response.IsSuccessStatusCode) return 0;

            var content = await response.Content.ReadAsStringAsync();
            var activityIndex = JsonConvert.DeserializeObject<double>(content);
            return activityIndex;
        }
    }
}
