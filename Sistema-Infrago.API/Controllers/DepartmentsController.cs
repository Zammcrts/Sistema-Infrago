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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var department = await dataContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Department department)
        {
            dataContext.Departments.Add(department);
            await dataContext.SaveChangesAsync();
            return Ok(department);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Department department)
        {
            dataContext.Departments.Update(department);
            await dataContext.SaveChangesAsync();
            return Ok(department);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Departments.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
