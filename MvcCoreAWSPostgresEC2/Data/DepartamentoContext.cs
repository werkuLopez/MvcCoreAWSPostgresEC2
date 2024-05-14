using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Models;

namespace MvcCoreAWSPostgresEC2.Data
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
