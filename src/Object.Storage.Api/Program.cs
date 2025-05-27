using Minio;

var builder = WebApplication.CreateBuilder(args);

var endpoint = "localhost:9000";
var accessKey = "ROOTNAME";
var secretKey = "CHANGEME123";

//builder.Services.AddMinio(accessKey, secretKey);

builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(endpoint)
    .WithCredentials(accessKey, secretKey)
    .WithSSL(false)
    .Build());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
