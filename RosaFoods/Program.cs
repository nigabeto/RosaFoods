
using Microsoft.EntityFrameworkCore;
using RosaFoods.Areas.Admin.Servicos;
using RosaFoods.Context;
using RosaFoods.Models;
using RosaFoods.Repositories.Interfaces;
using RosaFoods.Repositories;
using RosaFoods.Services;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connection));

//Opcionalmente poderia ser declarada da seguinte forma sem a variavel connection:
//builder.Services.AddDbContext<AppDbContext>(options =>
//           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<IdentityOptions>(options =>
        {// Regras default para criaçao de senhas (alterar para produção)
            options.Password.RequireDigit = false;   
            options.Password.RequireLowercase = false;   
            options.Password.RequireUppercase = false;   
            options.Password.RequireNonAlphanumeric = false; 
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;    
        });

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();


  //Registro de serviço para que toda vez que for solicitada uma instancia referenciando a interface, a injeçao de dependencia será feita no contrutor
        builder.Services.Configure<ConfigurationImagens>(builder.Configuration.GetSection("ConfigurationPastaImagens"));
        builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
        builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();

        builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>(); 
        builder.Services.AddScoped<RelatorioVendasService>();
        builder.Services.AddScoped<GraficoVendasService>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                politica =>
                {
                    politica.RequireRole("Admin");
                });
        });

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        builder.Services.AddControllersWithViews();
        builder.Services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";

        });

        builder.Services.AddMemoryCache();
        builder.Services.AddSession();

var app = builder.Build();  

if (app.Environment.IsDevelopment())
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

CriarPerfisUsuarios(app);

        ////Criar os perfis primeiro
        //seedUserRoleInitial.SeedRoles();
        ////Depois criar os usuarios e atribuir ao perfil
        //seedUserRoleInitial.SeedUsers();    

        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        #pragma warning disable ASP0014
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

app.Run();  

void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedUsers();
        service.SeedRoles();
    }
}