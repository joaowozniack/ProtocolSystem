using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models;

namespace ProtocolSystem
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Protocolo> Protocolos { get; set; }
        public DbSet<ProtocoloFollow> ProtocoloFollows { get; set; }
        public DbSet<StatusProtocolo> StatusProtocolos { get; set; }
    }
}
