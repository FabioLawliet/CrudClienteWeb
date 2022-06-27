using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CrudClienteWeb.Models
{
    [Table("estado", Schema = "public")]
    public class DbEstado
    {
        [Key]
        public int idestado { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
    }
}
