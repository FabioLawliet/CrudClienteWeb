using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CrudClienteWeb.Models
{
    [Table("clientes", Schema = "public")]
    public class DbCliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cpfcnpj { get; set; }
        public string rgie { get; set; }
        public bool ativo { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public int idcidade { get; set; }
        public int idestado { get; set; }

    }
}
