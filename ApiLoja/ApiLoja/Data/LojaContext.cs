using ApiLoja.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLoja.Data
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
