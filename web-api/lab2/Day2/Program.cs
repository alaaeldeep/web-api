
using Day2.BL;
using Day2.DAL;
using Microsoft.EntityFrameworkCore;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region database
            var connectionString = builder.Configuration.GetConnectionString("CS");
            builder.Services.AddDbContext<ProjectContext>(
                options => options.UseSqlServer(connectionString));
            # endregion

            builder.Services.AddScoped<IDepartmentManager,DepartmentManager>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}