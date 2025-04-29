using System.Net;
using TinyEarth.Models;

namespace TinyEarth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddHttpClient<PlanService>();

            builder.Services.AddHttpClient<PlanService>(client =>
            {
                client.BaseAddress = new Uri("http://plan.tiny-earth.com:25569/");
            }).ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Custom route til /Rules ? HomeController.Rules
            app.MapControllerRoute(
                name: "rules",
                pattern: "Rules",
                defaults: new { controller = "Home", action = "Rules" });


            app.MapControllerRoute(
                name: "safety",
                pattern: "Safety",
                defaults: new { controller = "Home", action = "Safety" });


            app.MapControllerRoute(
                name: "media",
                pattern: "Media",
                defaults: new { controller = "Home", action = "Media" });

            app.MapControllerRoute(
                name: "vote",
                pattern: "Vote",
                defaults: new { controller = "Home", action = "Vote" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
