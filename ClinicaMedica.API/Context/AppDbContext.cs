using ClinicaMedica.API.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }
        public DbSet<CLI_USUARIO> CLI_USUARIO { get; set; }
        public DbSet<CLI_MEDICOS> CLI_MEDICOS { get; set; }
    }
}
