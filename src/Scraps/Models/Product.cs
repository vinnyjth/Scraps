using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scraps.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int Sku { get; set; }
        public int LotNumber { get; set; }
        public decimal Price { get; set; }
        public decimal ProductionCost { get; set; }
        public decimal CalculateProfit()
        {
            return this.Price - this.ProductionCost;
        }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
