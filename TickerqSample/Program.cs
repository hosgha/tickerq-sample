using TickerQ.DependencyInjection;
using TickerqSample.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTickerQServices(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseTickerQ();

await app.UseTickerQJobsAsync();

await app.RunAsync();