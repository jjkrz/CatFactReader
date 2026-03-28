using CatFactReaderApi.Handlers;
using CatFactReaderApi.Interfaces;
using CatFactReaderApi.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var catFactApiBaseUrl = builder.Configuration["CatFactApi:BaseUrl"] ?? throw new Exception("No BaseUrl for CatFactApi in configuration.");

builder.Services.AddHttpClient<ICatFactService, CatFactService>(
    c =>
    {
        c.BaseAddress = new Uri(catFactApiBaseUrl);
    });

builder.Services.AddSerilog(
    (services, configuration) => {
        configuration.ReadFrom.Configuration(builder.Configuration);
    });

builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
