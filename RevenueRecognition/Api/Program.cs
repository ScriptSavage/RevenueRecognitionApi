using Api.Middlewares;
using Bal.Extensions;
using Dal.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessAccessLayer();
builder.Services.AddSingleton<GlobalErrorHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); 
}

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
