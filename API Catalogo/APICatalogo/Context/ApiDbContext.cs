using APICatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {} 

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get;set; }

    }
}
