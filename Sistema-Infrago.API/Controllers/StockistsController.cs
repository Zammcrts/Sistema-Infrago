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

        [HttpPost]
        public async Task<IActionResult> PostAsync(Stockist stockist) //http results
        {
            dataContext.Stockists.Add(stockist); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(stockist);
        }
    }
}
