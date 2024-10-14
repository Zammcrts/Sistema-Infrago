using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/stockists")]
    public class StockistsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public StockistsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Stockists.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var stockist = await dataContext.Stockists.FirstOrDefaultAsync(x => x.Id == id);
            if (stockist == null)
            {
                return NotFound();
            }
            return Ok(stockist);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Stockist stockist)
        {
            dataContext.Stockists.Add(stockist);
            await dataContext.SaveChangesAsync();
            return Ok(stockist);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Stockist stockist)
        {
            dataContext.Stockists.Update(stockist);
            await dataContext.SaveChangesAsync();
            return Ok(stockist);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Stockists.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
