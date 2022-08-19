using Crud_Escola.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Crud_Escola.Models;
using Microsoft.EntityFrameworkCore;
using Crud_Escola.ViewModels;

namespace Crud_Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        [HttpGet]
        [Route("BuscarTurmas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var turmas = await context.Turmas.AsNoTracking().ToListAsync();

            return Ok(turmas);
        }

        [HttpGet]
        [Route("BuscarTurma/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var turma = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return turma == null ? NotFound() : Ok(turma);
        }

        [HttpPost]
        [Route("CriarTurma")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateTurmaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var turma = new Turma
                {
                    IdSchool = model.IdSchool,
                    Name = model.Name
                };
                await context.Turmas.AddAsync(turma);
                await context.SaveChangesAsync();
                return Created(uri: $"Turma/turmas/{turma.Id}", turma);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AdicionarTurmas")]
        public async Task<IActionResult> PostListAsync([FromServices] AppDbContext context, [FromBody] List<CreateTurmaViewModel> model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var listTurmas = new List<Turma>();
                foreach (var a in model)
                {
                    var turma = new Turma
                    {
                        Name = a.Name,
                        IdSchool = a.IdSchool
                    };
                    listTurmas.Add(turma);
                }

                await context.Turmas.AddRangeAsync(listTurmas);
                await context.SaveChangesAsync();
                return Created(uri: $"Turma/turmas/{listTurmas}", listTurmas);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("AtualizarTurma/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateTurmaViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var turma = await context.Turmas.FirstOrDefaultAsync(x => x.Id == id);
            if (turma == null) return NotFound();

            try
            {
                turma.Name = model.Name;
                turma.IdSchool = model.IdSchool;

                context.Turmas.Update(turma);
                await context.SaveChangesAsync();
                return Ok(turma);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeletarTurma/{id}")]

        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var turma = await context.Turmas.FirstOrDefaultAsync(x => x.Id == id);
            if (turma == null) return NotFound();

            try
            {
                context.Turmas.Remove(turma);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}