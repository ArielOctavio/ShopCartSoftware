using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCartSoftware.Models
{
    public class VentaDetalle
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }


    }
}
