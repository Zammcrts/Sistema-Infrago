using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/tools")]
    public class ToolsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ToolsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Tools.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Tools.FirstOrDefaultAsync(x => x.ToolID == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Tool tool)
        {
            dataContext.Tools.Add(tool); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(tool); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(Tool tool)
        {
            dataContext.Tools.Update(tool);
            await dataContext.SaveChangesAsync();
            return Ok(tool);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.Tools.Where(X => X.ToolID == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
