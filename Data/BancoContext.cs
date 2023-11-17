using Agedamento.Models;

using Microsoft.EntityFrameworkCore;

namespace Agedamento.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 

        }
        public DbSet<PacientesModel> Pacientes { get; set; }
    }
}
