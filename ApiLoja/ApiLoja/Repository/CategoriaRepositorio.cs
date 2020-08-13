using ApiLoja.Data;
using ApiLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    public class CategoriaRepositorio : ICategoriaRepository
    {
        private readonly LojaContext _context;

        public CategoriaRepositorio(LojaContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria Find(int id)
        {
            return _context.Categoria.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categoria.ToList();
        }

        public void Remove(int id)
        {
            var categoria = Find(id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            _context.SaveChanges();
        }
    }
}
