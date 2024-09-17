
using FeedbackApplication.Models;
using FeedbackApplication.Repository.Implementation;
using FeedbackApplication.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FeedbackApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FeedbackDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                           .AddEntityFrameworkStores<FeedbackDbContext>()
                           .AddDefaultTokenProviders();


            builder.Services.AddCors(options => {
                options.AddPolicy("MyPolicy",
                                  policy => policy
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
                                  .AllowCredentials()
                                  .SetIsOriginAllowed(allow => true));
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"{builder.Configuration["JWT:ValidIssuer"]}",
                    ValidateAudience = true,
                    ValidAudience = $"{builder.Configuration["JWT:ValidAudience"]}",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{builder.Configuration["JWT:Secret"]}"))

                };
            });

            builder.Services.AddScoped<IOpinionRepository, OpinionRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");
            app.UseAuthorization();
            app.UseAuthentication();


            app.MapControllers();

            app.Run();
        }
    }
}
