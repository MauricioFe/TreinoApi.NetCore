using ApiLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria Find(int id);
        void Add(Categoria categoria);
        void Update(int id, Categoria categoria);
        void Remove(int id);
    }
}
