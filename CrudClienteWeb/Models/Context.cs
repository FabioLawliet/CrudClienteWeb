using Microsoft.EntityFrameworkCore;

namespace CrudClienteWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }

        public DbSet<DbCliente> clientes { get; set; }
        public DbSet<DbCidade> cidades { get; set; }
        public DbSet<DbEstado> estados { get; set; }

    }
}
