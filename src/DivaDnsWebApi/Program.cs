using DivaDnsWebApi.Contracts;
using DivaDnsWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHttpClient<IDivaService, DivaService>(c =>
{
    string divaServiceUrl = Environment.GetEnvironmentVariable("URL_API_CHAIN") ?? "http://localhost:17468/";
    c.BaseAddress = new Uri(divaServiceUrl);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline (middleware).
app.UseSwagger(); // Use() is a middleware that may act on the incoming request and on the returning response after next()
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); // Run() is the middleware that terminates the pipe line
