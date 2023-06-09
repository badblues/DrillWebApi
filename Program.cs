using DrillWebApi.Persistence;
using DrillWebApi.Persistence.Interfaces;

namespace DrillWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ApplicationContext>(serviceProvider =>
            {
                var settings = config.GetSection(nameof(DbSettings)).Get<DbSettings>();
                return new ApplicationContext(settings.ConnectionString);
            });
            builder.Services.AddSingleton<IDrillBlockRepository, DbDrillBlockRepository>();
            builder.Services.AddSingleton<IHoleRepository, DbHoleRepository>();
            builder.Services.AddSingleton<IHoleLocationRepository, DbHoleLocationRepository>();
            builder.Services.AddSingleton<IDrillBlockPointRepository, DbDrillBlockPointRepository>();

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