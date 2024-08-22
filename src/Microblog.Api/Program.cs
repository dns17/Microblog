using Microblog.Api.DependencyInjections;
using Microblog.Api.Endpoints;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMicroblogServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.RegisterPostEndpoint();
app.RegisterUserEndpoint();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.Run();