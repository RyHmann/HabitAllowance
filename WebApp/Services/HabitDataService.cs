using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class HabitDataService : IHabitDataService
    {
        private readonly HttpClient httpClient;
        public string ApiUrl { get; } = "api/v1";

        public HabitDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Habit>> GetAllHabits()
        {
            // TODO: Don't hardcode, especially API Version
            return await JsonSerializer.DeserializeAsync<IEnumerable<Habit>>(await httpClient.GetStreamAsync($"{ApiUrl}/habit"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Habit> GetHabitById(int habitId)
        {
            return await JsonSerializer.DeserializeAsync<Habit>(await httpClient.GetStreamAsync($"{ApiUrl}/habit/{habitId}"),
    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Habit> AddHabit(Habit habit)
        {
            var habitJson = new StringContent(JsonSerializer.Serialize(habit), Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await httpClient.PostAsync($"{ApiUrl}/habit", habitJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Habit>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }
        public async Task UpdateHabit(Habit habit)
        {
            var habitJson = new StringContent(JsonSerializer.Serialize(habit), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{ApiUrl}/habit/{habit.Id}", habitJson);
        }

        public async Task<string> DeleteHabitById(Habit habit)
        {
            var habitTitle = habit.Title;
            var response = await httpClient.DeleteAsync($"{ApiUrl}/habit/{habit.Id}");
            if (response.IsSuccessStatusCode)
            {
                return habitTitle;
            }
            return null;
        }
    }
}