using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ProjectsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Projects.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Project project) //http results
        {
            dataContext.Projects.Add(project); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(project);
        }
    }
}
