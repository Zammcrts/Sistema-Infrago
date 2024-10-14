using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/toolassignments")]
    public class ToolAssignmentsController : ControllerBase
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.ToolAssignments.FirstOrDefaultAsync(x => x.ToolAssignmentID == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(ToolAssignment toolAssignment)
        {
            dataContext.ToolAssignments.Add(toolAssignment); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(toolAssignment); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(ToolAssignment toolAssignment)
        {
            dataContext.ToolAssignments.Update(toolAssignment);
            await dataContext.SaveChangesAsync();
            return Ok(toolAssignment);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.ToolAssignments.Where(X => X.ToolAssignmentID == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
