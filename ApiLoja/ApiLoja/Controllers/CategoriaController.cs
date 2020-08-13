using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoja.Models;
using ApiLoja.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaController(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategorias()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public IActionResult GetById(int id)
        {
            var categoria = _repo.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return new ObjectResult(categoria);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            _repo.Add(categoria);
            return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Categoria categoria)
        {
            var _categoria = _repo.Find(id);
            if (_categoria == null)
            {
                return BadRequest();
            }
            _categoria.Nome = categoria.Nome;
            _repo.Update(_categoria);
            return CreatedAtRoute("GetCategoria", new { id = _categoria.Id}, _categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _repo.Find(id);
            if(categoria == null)
            {
                return NotFound();
            }

            _repo.Remove(id);
            return new NoContentResult();
        }
    }
}
