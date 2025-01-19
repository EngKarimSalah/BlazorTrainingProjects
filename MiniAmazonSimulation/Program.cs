using Microsoft.EntityFrameworkCore;
using MiniAmazonSimulation.Components;
using MiniAmazonSimulation.Data.Repositories;
using MiniAmazonSimulation.Services;

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

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
