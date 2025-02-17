using System.ComponentModel.DataAnnotations;

namespace ProtocolSystem.Models
{
    public class StatusProtocolo
    {
        [Key]
        public int IdStatus { get; set; }
        [Required, StringLength(50)]
        public string NomeStatus { get; set; }
        public ICollection<Protocolo> Protocolos { get; set; } = new List<Protocolo>();
    }
}
