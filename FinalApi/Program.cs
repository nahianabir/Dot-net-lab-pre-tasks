using FinalApi.Data;
using FinalApi.DTOS;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt=>opt.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);//to ignore cycles 
builder.Services.AddAutoMapper(typeof(MappingProfile)); //automapper init 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("InventoryDbContext");
builder.Services.AddDbContext<InventoryDbContext>(e => e.UseSqlServer(cs));

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
