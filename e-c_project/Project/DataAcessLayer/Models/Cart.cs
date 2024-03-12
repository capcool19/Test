using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public int Quantity { get; set; }

        public Cart(Product product, int quantity)
        {
            Product = product;
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = product.Price;
            Quantity = quantity;
            SubTotal = product.Price * quantity;
        }
    }
}
