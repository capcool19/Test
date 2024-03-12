using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class CategoryDAL
    {
        ProjectEntities db = new ProjectEntities();
        public List<Category> GetCategoryList()
        {
            var categories = db.Categories.ToList();
            return categories;
        }
        public void CreateNewCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public Category GetCategoryById(int? id)
        {
            Category category = db.Categories.Find(id);
            return category;
        }
        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
