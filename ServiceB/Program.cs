using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/GetServiceB", (IConfiguration configuration) =>
{
    return new Data() { ID = 1, Name = "·şÎñB", };
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

