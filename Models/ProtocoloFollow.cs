using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProtocolSystem.Models
{
    public class ProtocoloFollow
    {
        [Key]
        public int IdFollow { get; set; }

        [ForeignKey("Protocolo")]
        public int ProtocoloId { get; set; }
        public Protocolo Protocolo { get; set; }
        
        public DateTime DataAcao { get; set; } = DateTime.Now;
        public string DescricaoAcao { get; set; }
    }
}
