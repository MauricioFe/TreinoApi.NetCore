using ApiLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        Produto Find(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Remove (int id);
    }
}
