
using AutoService.Domain.Entities.Models.UserModels;
using AutoService.Infrastracture;
using AutoService.Infrastracture.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;

namespace AutoService.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
;
            builder.Services.AddRateLimiter(x =>
            {
                x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                x.AddTokenBucketLimiter("bucket", options =>
                {
                    options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
                    options.TokenLimit = 60;
                    options.TokensPerPeriod = 20;
                    options.AutoReplenishment = true;
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ServiceDbContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddRateLimiter(x =>
            {
                x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                x.AddTokenBucketLimiter("bucket", options =>
                {
                    options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
                    options.TokenLimit = 60;
                    options.TokensPerPeriod = 20;
                    options.AutoReplenishment = true;
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

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

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "TeamLead", "Backend", "Frondend", "Fullstack" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            app.Run();
        }
    }
}
