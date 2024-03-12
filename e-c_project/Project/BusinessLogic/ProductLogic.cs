using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class ProductLogic
    {
        ProductDAL dal = new ProductDAL();

        public List<Product> GetProductList()
        {
            var products = dal.GetProductList();
            return products;
        }

        public List<Product> GetProductList(int?category)
        {
            var products = dal.GetProductList(category);
            return products;
        }
        public List<Category> GetCategoryList()
        {
            var cats = dal.GetCategoryList();
            return cats;
        }

        public void CreateNewProduct(Product product)
        {
            dal.CreateNewProduct(product);
        }
        public Product GetProductById(int? id)
        {
            Product product = dal.GetProductById(id);
            return product;
        }
        public void UpdateProduct(Product product)
        {
            dal.UpdateProduct(product);
        }
        public void DeleteProduct(int id)
        {
            dal.DeleteProduct(id);
        }
    }
}
