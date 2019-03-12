using BlackJack.BusinessLogic.Config;
using BlackJack.BusinessLogic.Models;
using BlackJack.WEB.Filters;
using BlackJack.WEB.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BlackJack.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            var options = Configuration.GetSection("JWTOptions");

            services.DataBaseConfigures(connection);
            services.IdentityConfigures();
            services.OptionsConfigures(options);
            services.JwtConfigures();
            services.InjectConfigures();

            services.AddMvc(conf=> 
            {
                conf.Filters.Add(typeof(ValidateModelStateFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            /*app.Map("/app1", app1 =>
            {
                app1.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action}/{id?}");
                });
                app1.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";
                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start --app=app1 --base-href=/app1/ --serve-path=/");
                        spa.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:5000");
                    }
                });               
            });*/
            app.UseMvcWithDefaultRoute();
            /*app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(Path.Combine(env.ContentRootPath, "ClientApp\\src\\index.html"));
            });*/
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:5000");
                }
            });
            //app.UseMvcWithDefaultRoute();
            /*app.Use(async (context, next) =>
            {
                string token = context.Request.Cookies["token"]?.ToString();
                if (context.Request.Path.Value.Contains("/Attachments"))
                {
                    context.Response.StatusCode = 403;
                    return;
                }
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });*/
            //app.UseMvcWithDefaultRoute();

            /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            }); */

            /*app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:4200");
                }
            });*/
        }
    }
}
