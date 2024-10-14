using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ServicesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Services.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Services.FirstOrDefaultAsync(x => x.ServiceID == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Service service)
        {
            dataContext.Services.Add(service); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(service); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(Service service)
        {
            dataContext.Services.Update(service);
            await dataContext.SaveChangesAsync();
            return Ok(service);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.Services.Where(X => X.ServiceID == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
