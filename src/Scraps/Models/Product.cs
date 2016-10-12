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
            return (this.Price - this.ProductionCost) * this.Quantity;
        }
        public decimal TotalProfit { get; set; }
        public int CalculateOnHand()
        {
            if (this.Quantity < 60)
            {
                return 60 - this.Quantity;
            }
            else
            {
                return 0;
            }
        }
        public int TotalOnHand { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
