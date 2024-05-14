using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSPostgresEC2.Models;
using MvcCoreAWSPostgresEC2.Repositories;

namespace MvcCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private DepartamentoRepository repo;

        public DepartamentosController(DepartamentoRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos =
                await this.repo.GetDepartamentosAsync();

            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento =
                await this.repo.FindDepartamentoById(id);

            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string localidad)
        {
            Departamento departamento =
                await this.repo.Insertar(nombre, localidad);

            return RedirectToAction("Details", new { id = departamento.IdDepartamento });
        }
    }
}
