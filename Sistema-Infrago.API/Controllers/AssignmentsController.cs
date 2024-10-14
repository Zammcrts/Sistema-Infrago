using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public AssignmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Assignments.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var assignment = await dataContext.Assignments.FirstOrDefaultAsync(x => x.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Assignment assignment)
        {
            dataContext.Assignments.Add(assignment);
            await dataContext.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Assignment assignment)
        {
            dataContext.Assignments.Update(assignment);
            await dataContext.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Assignments.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
