using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ClientsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Clients.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Client client) //http results
        {
            dataContext.Clients.Add(client); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(client);
        }
    }
}
