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
            [HttpPost]

            public async Task<IActionResult> PostAsync(Machinery machinery)
            {
                dataContext.Machineries.Add(machinery); // se agrega al contexto de datos la carera :p
                await dataContext.SaveChangesAsync();
                return Ok(machinery); // agrega los datos al servidor epicooo

            }
        }
}
