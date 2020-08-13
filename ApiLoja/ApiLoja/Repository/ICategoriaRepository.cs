using ApiLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria Find(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(int id);
    }
}
