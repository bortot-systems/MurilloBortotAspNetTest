﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurilloBortotAspNetTest.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}