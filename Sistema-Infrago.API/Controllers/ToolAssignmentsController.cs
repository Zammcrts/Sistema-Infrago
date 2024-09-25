using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/toolassignments")]
    public class ToolAssignmentsController: ControllerBase
    {
        private readonly DataContext dataContext;

        public ToolAssignmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.ToolAssignments.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(ToolAssignment toolAssignment)
        {
            dataContext.ToolAssignments.Add(toolAssignment); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(toolAssignment); // agrega los datos al servidor epicooo

        }
    }
}
