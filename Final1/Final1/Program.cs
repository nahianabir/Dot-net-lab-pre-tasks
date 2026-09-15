
using System.Text.Json.Serialization;
using Final1.Data;
using Final1.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Final1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddAuthentication("Myapi").
                AddCookie("Myapi", opt =>
                {
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                });

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var cs = builder.Configuration.GetConnectionString("HosipitalDbContext");
            builder.Services.AddDbContext<HospitalContext>(opt=>opt.UseSqlServer(cs));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
