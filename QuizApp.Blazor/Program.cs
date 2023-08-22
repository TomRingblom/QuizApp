using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuizApp.Blazor;
using QuizApp.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var rootComponents = builder.RootComponents;
var services = builder.Services;
var configuration = builder.Configuration;

rootComponents.Add<App>("#app");
rootComponents.Add<HeadOutlet>("head::after");

//services.AddHttpClient("QuizApp.Api", client =>
//{
//    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//});

//services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("QuizApp.Api"));

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
services.AddScoped<IChatGptService, ChatGptService>();
//services.AddHttpClient<IChatGptService, ChatGptService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));



await builder.Build().RunAsync();
