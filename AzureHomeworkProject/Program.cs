using AzureHomeworkProject.AI;
using AzureHomeworkProject.Business.Abstract;
using AzureHomeworkProject.Business.Implementation;
using AzureHomeworkProject.Models;
using AzureHomeworkProject.Repository.Abstract;
using AzureHomeworkProject.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

#if DEBUG
builder.Environment.EnvironmentName = "development";
#else
builder.Environment.EnvironmentName = "production";
#endif

var configuration = builder.Configuration;
var azureInformations = configuration.GetSection("AzureInformations");

if (!azureInformations.Exists() || azureInformations["Endpoint"] is null || azureInformations["Endpoint"] is null)
{
    Console.WriteLine("You should configure your appsettings.json correctly, check documentation.");
    return;
}

builder.Services.AddDbContext<AppDbContext>((o) => o.UseSqlServer(configuration.GetConnectionString("AzureCommentDatabase")));
builder.Services.AddScoped<ITextAnalyzer>((x) => new TextAnalyzer(azureInformations["Endpoint"]!, azureInformations["Key"]!));

#region Repository Layer DI
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
#endregion
#region Business Layer DI
builder.Services.AddScoped<ICommentService, CommentManager>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
