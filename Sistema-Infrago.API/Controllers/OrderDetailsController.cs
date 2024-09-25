using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/orderDetails")]
    public class OrderDetailsController: ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderDetail orderdetail) //http results
        {
            dataContext.OrderDetails.Add(orderdetail); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(orderdetail);
        }
    }
}
