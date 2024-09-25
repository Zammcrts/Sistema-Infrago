using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/teachers")]
    public class ToolsController: ControllerBase
    {
        private readonly DataContext dataContext;

        public ToolsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Tools.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Tool tool)
        {
            dataContext.Tools.Add(tool); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(tool); // agrega los datos al servidor epicooo

        }
    }
}
