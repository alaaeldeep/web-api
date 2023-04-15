
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1
{
    public class Program
    {

        public static void Main(string[] args)
        {  
            int counter = 0;
            var builder = WebApplication.CreateBuilder(args);

            

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

            app.Use(async (context, next) =>
            {
                counter++;
                Console.WriteLine(counter);
                await next(context);
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}