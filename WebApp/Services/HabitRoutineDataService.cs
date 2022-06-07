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
    public class HabitRoutineDataService : IHabitRoutineDataService
    {
        private readonly HttpClient httpClient;

        public string ApiUrl { get; set; } = "api/v1";

        public HabitRoutineDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HabitRoutine> GetHabitRoutineById(int id)
        {
            return await JsonSerializer.DeserializeAsync<HabitRoutine>(await httpClient.GetStreamAsync($"{ApiUrl}/habitroutine/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<HabitRoutine> AddHabitRoutine(HabitRoutine habitRoutine)
        {
            var routineJson = new StringContent(JsonSerializer.Serialize(habitRoutine), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{ApiUrl}/HabitRoutine", routineJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<HabitRoutine>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task UpdateHabitRoutine(HabitRoutine habitRoutine)
        {
            var routineJson = new StringContent(JsonSerializer.Serialize(habitRoutine), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{ApiUrl}/habitroutine/{habitRoutine.Id}", routineJson);
        }

        public async Task<string> DeleteHabitRoutineById(HabitRoutine habitRoutine)
        {
            var routineTitle = habitRoutine.Title;
            var response = await httpClient.DeleteAsync($"{ApiUrl}/habitroutine/{habitRoutine.Id}");
            if (response.IsSuccessStatusCode)
            {
                return routineTitle;
            }
            return null;
        }
    }
}
