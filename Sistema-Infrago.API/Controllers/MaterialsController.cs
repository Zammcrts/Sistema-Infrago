using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/materials")]
    public class MaterialsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MaterialsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Materials.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var material = await dataContext.Materials.FirstOrDefaultAsync(x => x.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Material material)
        {
            dataContext.Materials.Add(material);
            await dataContext.SaveChangesAsync();
            return Ok(material);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Material material)
        {
            dataContext.Materials.Update(material);
            await dataContext.SaveChangesAsync();
            return Ok(material);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Materials.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
