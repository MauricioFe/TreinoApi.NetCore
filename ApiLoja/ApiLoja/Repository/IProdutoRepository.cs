﻿using ApiLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoja.Repository
{
    interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto Find(int id);
        void Add(Produto produto);
        void Update(int id, Produto produto);
        void Delete (int id);
    }
}
