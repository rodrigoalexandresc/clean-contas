using Clean.Domain.Contas;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infra.Data
{
    public class ContasDbContext : DbContext
    {
        public ContasDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContaReceber> ContasReceber { get; set; }
        public DbSet<ContaReceberParcela> ContasReceberParcelas { get; set; }
    }
}