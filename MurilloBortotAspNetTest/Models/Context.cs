using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MurilloBortotAspNetTest.Models
{
    public class Context: DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Venda> Venda { get; set; }

    }
}