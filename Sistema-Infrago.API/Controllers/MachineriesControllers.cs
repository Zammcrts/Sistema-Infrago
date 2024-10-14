using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/machineries")]
    public class MachineriesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MachineriesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Machineries.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Machineries.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Machinery teacher)
        {
            dataContext.Machineries.Add(teacher); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(teacher); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(Machinery teacher)
        {
            dataContext.Machineries.Update(teacher);
            await dataContext.SaveChangesAsync();
            return Ok(teacher);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.Machineries.Where(X => X.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
