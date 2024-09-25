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
        [HttpPost]

        public async Task<IActionResult> PostAsync(MaintenanceDetails maintenanceDetails)
        {
            dataContext.MaintenanceDetails.Add(maintenanceDetails); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(maintenanceDetails); // agrega los datos al servidor epicooo

        }
    }
}
