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
        [HttpPost]

        public async Task<IActionResult> PostAsync(Service service)
        {
            dataContext.Services.Add(service); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(service); // agrega los datos al servidor epicooo

        }
    }
}
