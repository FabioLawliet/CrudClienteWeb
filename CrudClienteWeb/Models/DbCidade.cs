using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudClienteWeb.Models
{
    [Table("cidades", Schema = "public")]
    public class DbCidade
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
    }
}
