using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeuProjetoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private static List<Professor> professores = new List<Professor>
        {
            new Professor { Id = 1, Nome = "Dr. Silva" },
            new Professor { Id = 2, Nome = "Prof. Santos" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> GetProfessores()
        {
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessor(int id)
        {
            var professor = professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost]
        public ActionResult<Professor> PostProfessor(Professor professor)
        {
            professores.Add(professor);
            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public IActionResult PutProfessor(int id, Professor professor)
        {
            var existingProfessor = professores.FirstOrDefault(p => p.Id == id);
            if (existingProfessor == null)
            {
                return NotFound();
            }
            existingProfessor.Nome = professor.Nome;
            // Atualize outros campos conforme necessário
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            professores.Remove(professor);
            return NoContent();
        }
    }
}
