using System.ComponentModel.DataAnnotations;

namespace ProtocolSystem.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
