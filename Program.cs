using BurgerPlace2.Areas.Admin.Services;
using BurgerPlace2.Context;
using BurgerPlace2.Models;
using BurgerPlace2.Repositories;
using BurgerPlace2.Repositories.Interfaces;
using BurgerPlace2.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPaging(options => {
options.ViewName = "Bootstrap5";
options.PageParameterName = "pageindex";});
builder.Services.AddScoped<RelatorioVendasServices>();
builder.Services.Configure<ConfiguraImagem>(builder.Configuration.GetSection("ConfImagemItem"));
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUserRoleInicial, UserRoleInicial>();
builder.Services.AddIdentity<UserAccount, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped(sp => Carrinho.GetCarrinhoCompra(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.
Configuration.GetConnectionString("DefaulConnection")));

builder.Services.AddControllersWithViews();

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
CriarPerfisUsuarios(app);
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
name: "categoriaFiltro",
pattern: "Item/{action}/{categoria?}",
defaults: new { Controller = "Item", action = "List" }
);

app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
static void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<IUserRoleInicial>();
    service?.SeedRoles();
    service?.SeedUsers();
}
