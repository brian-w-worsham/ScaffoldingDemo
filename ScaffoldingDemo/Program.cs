using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace ScaffoldingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                /*ResponseHeaderAttribute responseHeaderAttribute = new ResponseHeaderAttribute("header-1", "value-1");
                options.Filters.Add<ResponseHeaderAttribute>();*/
            });

            builder.Services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

            builder.Services.AddScoped<LoggingResponseHeaderFilterService>();
            
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

            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");*/

            app.MapControllerRoute("Everything", "{*url}", new
            {
                controller = "Everything",
                action = "Index",
            });

            /*app.MapControllerRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            }, new
            {
                id = @"\d+" // restriction for Id
            });*/


            app.MapControllerRoute("Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^Contact$",
                    httpMethod = new HttpMethodConstraint("GET", "POST")
                }); // localhost/Home/Index, localhost/Home/Contact
            app.Run();
        }
    }
}