using Dapr.Client;
using static Dapr.Client.Autogen.Grpc.v1.Dapr;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var client = new DaprClientBuilder().Build();
app.MapGet("/test/serviceA", async () =>
{
    var appId = "masa-dapr-test";

    var resp = await client.InvokeMethodAsync<Data>(HttpMethod.Get, appId, "/GetServiceA");

    return resp;
})
.WithOpenApi(operation =>
{
    operation.Description = "�˽ӿ���������ServiceA";
    return operation;
});

app.MapPost("/test/serviceB", async () =>
{
    var appId = "service-b";

    var resp = await client.InvokeMethodAsync<Data>(HttpMethod.Post, appId, "/GetServiceB");

    return resp;
})
.WithOpenApi(operation =>
{
    operation.Description = "�˽ӿ���������ServiceB";
    return operation;
});

app.Run();

class Data
{
    /// <summary>
    /// ��� 
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string? Token { get; set; }
}


