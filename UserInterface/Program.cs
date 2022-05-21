using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UserInterface.Data;
using UserInterface.Services;
using UserInterface.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// TODO: How to not hard code these values?
string uriString = "https://localhost:7061/";
Uri uri = new Uri(uriString);
builder.Services.AddHttpClient<IHabitDataService, HabitDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IHabitRoutineDataService, HabitRoutineDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IRewardDataService, RewardDataService>(client => client.BaseAddress = uri);
builder.Services.AddHttpClient<IHabitEventDataService, HabitEventDataService>(client => client.BaseAddress = uri);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

//app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
