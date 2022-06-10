using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudClienteWeb.Models
{
    [Table("estados", Schema = "public")]
    public class DbEstado
    {        
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        
    }
}
