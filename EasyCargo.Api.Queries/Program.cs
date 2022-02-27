using System;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Repositories.Implementation;
using EasyCargo.Api.Queries.Repositories.Interface;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


Task.Run(async () =>
    {
        await DB.InitAsync("EasyCargoReadDb",
            MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbSettings")));
    })
    .GetAwaiter()
    .GetResult();
builder.Services.AddScoped<IOrderReadRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();