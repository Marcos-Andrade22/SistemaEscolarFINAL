using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeuProjetoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private static List<Nota> notas = new List<Nota>
        {
            new Nota { Id = 1, AlunoId = 1, MateriaId = 1, Valor = 8 },
            new Nota { Id = 2, AlunoId = 2, MateriaId = 2, Valor = 7 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Nota>> GetNotas()
        {
            return Ok(notas);
        }

        [HttpGet("{id}")]
        public ActionResult<Nota> GetNota(int id)
        {
            var nota = notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
            {
                return NotFound();
            }
            return Ok(nota);
        }

        [HttpPost]
        public ActionResult<Nota> PostNota(Nota nota)
        {
            notas.Add(nota);
            return CreatedAtAction(nameof(GetNota), new { id = nota.Id }, nota);
        }

        [HttpPut("{id}")]
        public IActionResult PutNota(int id, Nota nota)
        {
            var existingNota = notas.FirstOrDefault(n => n.Id == id);
            if (existingNota == null)
            {
                return NotFound();
            }
            existingNota.AlunoId = nota.AlunoId;
            existingNota.MateriaId = nota.MateriaId;
            existingNota.Valor = nota.Valor;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNota(int id)
        {
            var nota = notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
            {
                return NotFound();
            }
            notas.Remove(nota);
            return NoContent();
        }
    }
}
