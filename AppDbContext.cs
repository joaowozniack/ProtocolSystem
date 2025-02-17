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
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Um Status pode estar em vários Protocolos
            modelBuilder.Entity<Protocolo>()
                .HasOne(p => p.ProtocoloStatus)
                .WithMany(s => s.Protocolos)
                .HasForeignKey(p => p.ProtocoloStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
