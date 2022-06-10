using Microsoft.EntityFrameworkCore;
using CrudClienteWeb.Models;

namespace CrudClienteWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }
        public DbSet<DBClientes> clientes { get; set; }
        //public DBSet<DBCidades> cidades { get; set; }
        //public DBSet<DBEstado> estado { get; set; }

    }
}
