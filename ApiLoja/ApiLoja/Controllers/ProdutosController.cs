using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLoja.Models;
using ApiLoja.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;

namespace ApiLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repo;

        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public List<Produto> GetProdutos()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public IActionResult GetById(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return new ObjectResult(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (produto == null)
            {
                BadRequest();
            }
            _repo.Add(produto);
            return CreatedAtRoute("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Produto produto)
        {
            var _produto = _repo.Find(id);
            if (_produto == null)
            {
                return BadRequest();
            }

            _produto.Nome = produto.Nome;
            _produto.Preco = produto.Preco;
            _produto.Categoria_id = produto.Categoria_id;
            _repo.Update(_produto);
            return CreatedAtRoute("GetProduto", new { id = _produto }, _produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null)
            {
                NotFound();
            }
            _repo.Remove(id);
            return new NoContentResult();
        }
    }
}
