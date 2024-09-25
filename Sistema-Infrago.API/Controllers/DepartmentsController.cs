using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public DepartmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Departments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Department department) //http results
        {
            dataContext.Departments.Add(department); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(department);
        }
    }
}
