using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeuProjetoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "João" },
            new Aluno { Id = 2, Nome = "Maria" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAlunos()
        {
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetAluno(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost]
        public ActionResult<Aluno> PostAluno(Aluno aluno)
        {
            alunos.Add(aluno);
            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno)
        {
            var existingAluno = alunos.FirstOrDefault(a => a.Id == id);
            if (existingAluno == null)
            {
                return NotFound();
            }
            existingAluno.Nome = aluno.Nome;
            // Atualize outros campos conforme necessário
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            alunos.Remove(aluno);
            return NoContent();
        }
    }
}
