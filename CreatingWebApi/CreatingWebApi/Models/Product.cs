using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingWebApi
{
    public class Product
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StockAmount { get; set; }
    }
}
