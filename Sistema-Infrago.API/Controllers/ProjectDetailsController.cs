using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/projectdetails")]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ProjectDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.ProjectDetails.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(ProjectDetails projectDetails)
        {
            dataContext.ProjectDetails.Add(projectDetails); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(projectDetails); // agrega los datos al servidor epicooo

        }
    }
}
