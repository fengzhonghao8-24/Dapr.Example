using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDaprStarter(builder.Configuration.GetSection("DaprOptions"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/GetServiceA", (IConfiguration configuration) =>
{
    return new Data() { ID = 1, Name = "·şÎñA", };
});

app.Run();

class Data
{
    /// <summary>
    /// ±àºÅ 
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Ãû³Æ
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string? Token { get; set; }
}