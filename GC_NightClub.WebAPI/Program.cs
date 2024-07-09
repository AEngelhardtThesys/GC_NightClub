using GC_NightClub.WebAPI.Domain;
using GC_NightClub.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace GC_NightClub.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services
                .AddDbContext<NightClubDbContext>(
                    db => db.UseSqlServer(builder.Configuration.GetConnectionString("NightClubConnectionString")),
                    ServiceLifetime.Singleton);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEntityService<IdentityCard, Guid>, EntityService<IdentityCard, Guid>>();
            builder.Services.AddScoped<IEntityService<MemberCard, string>, EntityService<MemberCard, string>>();

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
