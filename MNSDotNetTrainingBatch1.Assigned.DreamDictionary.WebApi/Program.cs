using Microsoft.EntityFrameworkCore;
using MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Database.Models;
using MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => 
{
    string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<BlogService>();

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
