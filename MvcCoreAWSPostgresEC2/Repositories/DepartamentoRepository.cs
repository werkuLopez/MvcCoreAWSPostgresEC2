using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Models;

namespace MvcCoreAWSPostgresEC2.Repositories
{
    public class DepartamentoRepository
    {
        private DepartamentoContext context;

        public DepartamentoRepository(DepartamentoContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoById(int iddepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == iddepartamento);
        }

        public async Task<Departamento> Insertar(string nombre, string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = await this.GetMaxIdDepartamento(),
                Localidad = localidad,
                Nombre = nombre,
            };

            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();

            return departamento;
        }

        private async Task<int> GetMaxIdDepartamento()
        {
            if (this.context.Departamentos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Departamentos.MaxAsync(x => x.IdDepartamento) + 1;
            }
        }
    }
}
