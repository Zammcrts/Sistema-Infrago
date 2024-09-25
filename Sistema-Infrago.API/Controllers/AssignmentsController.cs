using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.API.Data;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Controllers
{
    [ApiController]
    [Route("/api/assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public AssignmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Assignments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Assignment assignment) //http results
        {
            dataContext.Assignments.Add(assignment); //se agrega
            await dataContext.SaveChangesAsync(); //salva los changos
            return Ok(assignment);
        }

    }
}
