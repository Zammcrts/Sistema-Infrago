using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public OrdersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Orders.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Order order) //http results
        {
            dataContext.Orders.Add(order); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(order);
        }
    }
}
