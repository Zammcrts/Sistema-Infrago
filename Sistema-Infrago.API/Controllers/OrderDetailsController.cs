using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/orderDetails")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public OrderDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.OrderDetails.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var orderDetail = await dataContext.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderDetail orderDetail)
        {
            dataContext.OrderDetails.Add(orderDetail);
            await dataContext.SaveChangesAsync();
            return Ok(orderDetail);
        }

        [HttpPut]
        public async Task<ActionResult> Put(OrderDetail orderDetail)
        {
            dataContext.OrderDetails.Update(orderDetail);
            await dataContext.SaveChangesAsync();
            return Ok(orderDetail);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.OrderDetails.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
