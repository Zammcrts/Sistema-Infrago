using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/machineryassignments")]

    public class MachineryAssignmentsController : ControllerBase
    {
            private readonly DataContext dataContext;

            public MachineryAssignmentsController(DataContext dataContext)
            {
                this.dataContext = dataContext;
            }

            [HttpGet]
            public async Task<IActionResult> GetAsync()
            {
                return Ok(await dataContext.MachineryAssignments.ToListAsync());
            }
            [HttpPost]

            public async Task<IActionResult> PostAsync(MachineryAssignment machineryAssignment)
            {
                dataContext.MachineryAssignments.Add(machineryAssignment); // se agrega al contexto de datos la carera :p
                await dataContext.SaveChangesAsync();
                return Ok(machineryAssignment); // agrega los datos al servidor epicooo

            }
    }
}
