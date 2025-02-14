using System.ComponentModel.DataAnnotations;

namespace ProtocolSystem.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required, StringLength(100)]
        public string Nome { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string Telefone { get; set; }
        [Required, StringLength(200)]
        public string Endereco { get; set; }
    }
}
