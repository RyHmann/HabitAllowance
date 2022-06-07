using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WebApp;
using WebApp.Services;
using WebApp.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// TODO: How to not hard code this...
string uriString = "https://localhost:7061/";
Uri uri = new Uri(uriString);

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = uri });

builder.Services.AddHttpClient<IHabitDataService, HabitDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IHabitEventDataService, HabitEventDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IHabitRoutineDataService, HabitRoutineDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IRewardDataService, RewardDataService>(client => client.BaseAddress = uri);

builder.Services.AddMudServices();

await builder.Build().RunAsync();
