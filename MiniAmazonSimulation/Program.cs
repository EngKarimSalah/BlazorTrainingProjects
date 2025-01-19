using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniAmazonSimulation.Components;
using MiniAmazonSimulation.Data.Repositories;
using MiniAmazonSimulation.Services;
using MiniAmazonSimulation.Helpers;

using MudBlazor.Services;
using System.Text;
using Microsoft.Extensions.Configuration;
using JWTAuthentication;
using Serilog;

namespace MiniAmazonSimulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(

                 options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                  );

            //Services registeration
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<ISellerRepo, SellerRepo>();  
            builder.Services.AddScoped<IClientRepo, ClientRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductReviewRepo, ProductReviewRepo>();
            builder.Services.AddScoped<IProductImagesRepo, ProductImagesRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISellerService, SellerService>();
            builder.Services.AddScoped<IClientService, ClientService>();    
            builder.Services.AddScoped<IProductService, ProductService>();  
            builder.Services.AddScoped<IProductReviewSerice, ProductReviewSerice>();
            builder.Services.AddScoped<IProductImagesService, ProductImagesService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<ICompoundServices, CompoundServices>();

            builder.Services.AddMudServices();

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var key = Encoding.ASCII.GetBytes("SecureKeyForBlazorCourseSecureKeyForBlazorCourse");


            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))

                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Seller", policy => policy.RequireRole("Seller"));
                options.AddPolicy("Client", policy => policy.RequireRole("Client"));
            });
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<ICountriesService, CountriesService>();

            
            builder.Services.AddHttpClient<CountriesService>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.BaseAddress = new Uri("https://restcountries.com/");
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
            });


            // Cors service
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            // Configure Serilog
            // Load Serilog configuration from JSON
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();


            builder.Host.UseSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Serilog request logging
            app.UseSerilogRequestLogging();

            // Cors middleware
            app.UseCors("AllowAll");


            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();



            app.Run();
        }
    }
}
