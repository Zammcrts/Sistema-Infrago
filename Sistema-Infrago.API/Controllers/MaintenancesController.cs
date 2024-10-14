using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/maintenances")]
    public class MaintenancesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MaintenancesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Maintenances.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Maintenances.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Maintenance maintenance)
        {
            dataContext.Maintenances.Add(maintenance); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(maintenance); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(Maintenance maintenance)
        {
            dataContext.Maintenances.Update(maintenance);
            await dataContext.SaveChangesAsync();
            return Ok(maintenance);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.Maintenances.Where(X => X.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
