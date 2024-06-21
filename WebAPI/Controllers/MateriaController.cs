using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeuProjetoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private static List<Materia> materias = new List<Materia>
        {
            new Materia { Id = 1, Nome = "Matemática" },
            new Materia { Id = 2, Nome = "Português" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Materia>> GetMaterias()
        {
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public ActionResult<Materia> GetMateria(int id)
        {
            var materia = materias.FirstOrDefault(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }
            return Ok(materia);
        }

        [HttpPost]
        public ActionResult<Materia> PostMateria(Materia materia)
        {
            materias.Add(materia);
            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, materia);
        }

        [HttpPut("{id}")]
        public IActionResult PutMateria(int id, Materia materia)
        {
            var existingMateria = materias.FirstOrDefault(m => m.Id == id);
            if (existingMateria == null)
            {
                return NotFound();
            }
            existingMateria.Nome = materia.Nome;
            // Atualize outros campos conforme necessário
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMateria(int id)
        {
            var materia = materias.FirstOrDefault(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }
            materias.Remove(materia);
            return NoContent();
        }
    }
}
