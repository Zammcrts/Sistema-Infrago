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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.MachineryAssignments.FirstOrDefaultAsync(x => x.MachineryAssignmentID == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(MachineryAssignment machineryAssignment)
        {
            dataContext.MachineryAssignments.Add(machineryAssignment); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(machineryAssignment); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(MachineryAssignment machineryAssignment)
        {
            dataContext.MachineryAssignments.Update(machineryAssignment);
            await dataContext.SaveChangesAsync();
            return Ok(machineryAssignment);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.MachineryAssignments.Where(X => X.MachineryAssignmentID == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
