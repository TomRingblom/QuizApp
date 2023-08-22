using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Configuration.Options;
using QuizApp.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddControllers();
services.AddRazorPages();
services.AddControllersWithViews();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddRouting(o => o.LowercaseUrls = true);
services.AddDbContext<QuizDbContext>(x => x
    .UseSqlServer(configuration.GetConnectionString("QuizDb")));

services.AddHttpClient("ChatGptClient", client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/completions");
});
services.Configure<ChatGptOptions>(
                options => configuration.GetSection(ChatGptOptions.ChatGpt)
                    .Bind(options));

//services.AddCors(options =>
//{
//    options.AddPolicy("Open", builder => builder
//        .AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod());
//});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseBlazorFrameworkFiles();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
