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

        [HttpPost]
        public async Task<IActionResult> PostAsync(Material material) //http results
        {
            dataContext.Materials.Add(material); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(material);
        }
    }
}
