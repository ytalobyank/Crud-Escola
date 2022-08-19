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
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("BuscarAlunos")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var alunos = await context.Alunos.AsNoTracking().ToListAsync();

            return Ok(alunos);
        }

        [HttpGet]
        [Route("BuscarAluno/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return aluno == null ? NotFound() : Ok(aluno);
        }

        [HttpPost]
        [Route("CriarAluno")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateAlunoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var aluno = new Aluno
                {
                    Name = model.Name,
                    Age = model.Age,
                    IdSchool = model.IdSchool,
                    IdClassroom = model.IdClassroom

                };
                await context.Alunos.AddAsync(aluno);
                await context.SaveChangesAsync();
                return Created(uri: $"Turma/turmas/{aluno.Id}", aluno);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AdicionarAlunos")]
        public async Task<IActionResult> PostListAsync([FromServices] AppDbContext context, [FromBody] List<CreateAlunoViewModel> model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var listAlunos = new List<Aluno>();
                foreach (var a in model)
                {
                    var aluno = new Aluno
                    {
                        Name = a.Name,
                        Age = a.Age,
                        IdSchool = a.IdSchool,
                        IdClassroom = a.IdClassroom
                    };
                    listAlunos.Add(aluno);
                }

                await context.Alunos.AddRangeAsync(listAlunos);
                await context.SaveChangesAsync();
                return Created(uri: $"Turma/turmas/{listAlunos}", listAlunos);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AtualizarAluno/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateAlunoViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (aluno == null) return NotFound();

            try
            {
                aluno.Name = model.Name;
                aluno.Age = model.Age;
                aluno.IdSchool = model.IdSchool;
                aluno.IdClassroom = model.IdClassroom;

                context.Alunos.Update(aluno);
                await context.SaveChangesAsync();
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeletarAluno/{id}")]

        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (aluno == null) return NotFound();

            try
            {
                context.Alunos.Remove(aluno);
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
