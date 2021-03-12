﻿using ShopCartSoftware.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCartSoftware.Models
{
    public class VentaCabecera
    {
        private ApplicationDbContext context;
        public VentaCabecera()
        {

             context = new ApplicationDbContext();
        }


        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string IdUsuario { get; set; }

        public List<VentaDetalle> Details { get; set; }


        [NotMapped]
        public List<Product> Products { get { return context.Product.ToList(); } }

    }
}