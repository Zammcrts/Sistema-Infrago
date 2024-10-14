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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.ProjectDetails.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(ProjectDetails projectDetails)
        {
            dataContext.ProjectDetails.Add(projectDetails); // se agrega al contexto de datos la carera :p
            await dataContext.SaveChangesAsync();
            return Ok(projectDetails); // agrega los datos al servidor epicooo

        }
        [HttpPut]
        public async Task<ActionResult> Put(ProjectDetails projectDetails)
        {
            dataContext.ProjectDetails.Update(projectDetails);
            await dataContext.SaveChangesAsync();
            return Ok(projectDetails);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await
                dataContext.ProjectDetails.Where(X => X.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
