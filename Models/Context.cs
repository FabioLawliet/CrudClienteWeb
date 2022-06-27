using Microsoft.EntityFrameworkCore;

namespace CrudClienteWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }

        public DbSet<DbCliente> cliente { get; set; }
        public DbSet<DbEstado> estado { get; set; }

    }
}
