using BurgerPlace2.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerPlace2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias{get;set;}
        public DbSet<Item> Itens{get;set;}
        public DbSet<CarrinhoItem> CarrinhoItens {get;set;}
    }
}