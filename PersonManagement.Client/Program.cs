using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonManagement.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<PersonHttpClient>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7049/") });

await builder.Build().RunAsync();
