using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;

namespace ProyectoLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseNpgsql(builder.Configuration.GetConnectionString("CadenaSQL"));
            });
            builder.Services.AddDbContext<UsuarioClienteContext>(o =>
            {
                o.UseNpgsql(builder.Configuration.GetConnectionString("CadenaSQL"));
            });
            builder.Services.AddScoped<IUsuarioClienteService, UsuarioClienteService>();
            builder.Services.AddScoped<IUsuarioNotariaService, UsuarioNotariaService>();
            builder.Services.AddScoped<IFilesService, FilesService>();
            builder.Services.AddScoped<IProcesoService, ProcesoService>();
            builder.Services.AddScoped<ITipoProcesoService, TipoProcesoService>();
            builder.Services.AddScoped<IArchivoService, ArchivoService>();
            builder.Services.AddScoped<ICotizacionService, CotizacionService>();
            builder.Services.AddScoped<IFacturaService, FacturaService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/IniciarSesion";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                });

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(
                    new ResponseCacheAttribute
                    {
                        NoStore = true,
                        Location = ResponseCacheLocation.None,
                    }
                   );
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=IniciarSesion}/{id?}");

            app.Run();
        }
    }
}