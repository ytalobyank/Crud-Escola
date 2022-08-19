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
    public class EscolaController : ControllerBase
    {
        [HttpGet]
        [Route("BuscarEscolas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var escolas = await context.Escolas.AsNoTracking().ToListAsync();

            return Ok(escolas);
        }

        [HttpGet]
        [Route("BuscarEscola/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var escola = await context.Escolas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return escola == null ? NotFound() : Ok(escola);
        }

        [HttpPost]
        [Route("CriarEscola")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateEscolaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var escola = new Escola
                {
                    Name = model.Name,
                    Address = model.Address,
                };
                await context.Escolas.AddAsync(escola);
                await context.SaveChangesAsync();
                return Created(uri: $"Turma/turmas/{escola.Id}", escola);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AtualizarEscola/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateEscolaViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var escola = await context.Escolas.FirstOrDefaultAsync(x => x.Id == id);
            if (escola == null) return NotFound();

            try
            {
                escola.Name = model.Name;
                escola.Address = model.Address;

                context.Escolas.Update(escola);
                await context.SaveChangesAsync();
                return Ok(escola);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeletarEscola/{id}")]

        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var escola = await context.Escolas.FirstOrDefaultAsync(x => x.Id == id);
            if (escola == null) return NotFound();

            try
            {
                context.Escolas.Remove(escola);
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
