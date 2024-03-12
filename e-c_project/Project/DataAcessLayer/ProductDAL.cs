using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class ProductDAL
    {
        ProjectEntities db = new ProjectEntities();
        public List<Product> GetProductList()
        {
            var products = db.Products.OrderByDescending(x => x.ProductId).ToList();
            return products;
        }
        public List<Product> GetProductList(int?category)
        {
            if (category != null)
            {
                var products = db.Products
                                 .OrderByDescending(x => x.ProductId)
                                 .Where(x=>x.CategoryId==category)
                                 .ToList();
                return products;
            }
            else
            {
                var products = db.Products.OrderByDescending(x => x.ProductId).ToList();
                return products;
            }
        }
        public List<Category> GetCategoryList()
        {
            var cats = db.Categories.ToList();
            return cats;
        }
        public void CreateNewProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public Product GetProductById(int? id)
        {
            Product product = db.Products.Find(id);
            return product;
        }
        public void UpdateProduct(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
