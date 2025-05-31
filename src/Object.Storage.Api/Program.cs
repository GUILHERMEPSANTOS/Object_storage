using Object.Storage.Api.Services.Images;
using Object.Storage.Api.Services.VIdeos;
using Object.Storage.Infra.Storage.Minio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMinioStorage(builder.Configuration);
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IVideoService, VideoService>();

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
