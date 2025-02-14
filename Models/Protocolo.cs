using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProtocolSystem.Models
{
    public class Protocolo
    {
        [Key]
        public int IdProtocolo { get; set; }
        [Required, StringLength(100)]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime DataFechamento { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("ProtocoloStatus")]
        public int ProtocoloStatusId { get; set; }
        public StatusProtocolo ProtocoloStatus { get; set; }

    }
}
