using ApiLoja.Data;
using ApiLoja.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaContext _context;

        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }
        public void Add(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }
        public Produto Find(int id)
        {
            return _context.Produto.Include(x => x.Categoria).FirstOrDefault(p => p.Id == id);
        }
        public List<Produto> GetAll()
        {
            return _context.Produto.Include(x => x.Categoria).ToList();
        }
        public void Remove(int id)
        {
            var produto = Find(id);
            _context.Produto.Remove(produto);
            _context.SaveChanges();

        }
        public void Update(Produto produto)
        {
            _context.Produto.Update(produto);
            _context.SaveChanges();
        }
    }
}
