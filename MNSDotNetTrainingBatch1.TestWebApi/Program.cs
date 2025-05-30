using Microsoft.Extensions.DependencyInjection;
using MNSDotNetTrainingBatch1.TestShared;
using MNSDotNetTrainingBatch1.TestWebApi.Models;
using MNSDotNetTrainingBatch1.TestWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

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
