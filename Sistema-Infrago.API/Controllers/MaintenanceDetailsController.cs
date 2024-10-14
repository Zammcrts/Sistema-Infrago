using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/maintenancedetails")]
    public class MaintenanceDetailsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MaintenanceDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.MaintenanceDetails.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.MaintenanceDetails.FirstOrDefaultAsync(x => x.MaintenanceID == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(MaintenanceDetails maintenanceDetails)
        {
            dataContext.MaintenanceDetails.Add(maintenanceDetails); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(maintenanceDetails); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(MaintenanceDetails maintenanceDetails)
        {
            dataContext.MaintenanceDetails.Update(maintenanceDetails);
            await dataContext.SaveChangesAsync();
            return Ok(maintenanceDetails);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.MaintenanceDetails.Where(X => X.MaintenanceID == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
