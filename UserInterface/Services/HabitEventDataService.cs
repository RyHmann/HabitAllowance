using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserInterface.Services.Interfaces;

namespace UserInterface.Services
{
    public class HabitEventDataService : IHabitEventDataService
    {
        private readonly HttpClient httpClient;
        public string ApiUrl { get; } = "api/v1";

        public HabitEventDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HabitEvent> AddHabitEvent(HabitEvent habitEvent)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(habitEvent), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{ApiUrl}/habitevent", eventJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<HabitEvent>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task<HabitEvent> GetHabitEventById(int id)
        {
            return await JsonSerializer.DeserializeAsync<HabitEvent>(await httpClient.GetStreamAsync($"{ApiUrl}/habitevent/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateHabitEvent(HabitEvent habitEvent)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(habitEvent), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{ApiUrl}/habitevent/{habitEvent.Id}", eventJson);
        }

        public async Task<string> DeleteHabitEventById(HabitEvent habitEvent)
        {
            var eventTitle = habitEvent.Title;
            var response = await httpClient.DeleteAsync($"{ApiUrl}/habitevent/{habitEvent.Id}");
            if (response.IsSuccessStatusCode)
            {
                return eventTitle;
            }
            return null;
        }
    }
}
