using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using RosaFoods.Areas.Admin.Servicos;
using RosaFoods.Context;
using RosaFoods.Models;
using RosaFoods.Repositories;
using RosaFoods.Repositories.Interfaces;
using RosaFoods.Services;

namespace RosaFoods;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();
        services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

        services.Configure<IdentityOptions>(options =>
        {// Regras default para criaçao de senhas (alterar para produção)
            options.Password.RequireDigit = false;   
            options.Password.RequireLowercase = false;   
            options.Password.RequireUppercase = false;   
            options.Password.RequireNonAlphanumeric = false; 
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;    
        });

        //Registro de serviço para que toda vez que for solicitada uma instancia referenciando a interface, a injeçao de dependencia será feita no contrutor
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddTransient<IPizzaRepository, PizzaRepository>();

        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>(); 
        services.AddScoped<RelatorioVendasService>();
        services.AddScoped<GraficoVendasService>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                politica =>
                {
                    politica.RequireRole("Admin");
                });
        });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        services.AddControllersWithViews();
        services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";

        });

        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //Criar os perfis primeiro
        seedUserRoleInitial.SeedRoles();
        //Depois criar os usuarios e atribuir ao perfil
        seedUserRoleInitial.SeedUsers();    

        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Pizza/{action}/{categoria?}",
                defaults: new { Controller = "Pizza", action = "List" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}