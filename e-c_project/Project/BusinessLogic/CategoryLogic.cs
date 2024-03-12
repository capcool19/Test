using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{
    public class CategoryLogic
    {
        CategoryDAL dal = new CategoryDAL();
        public List<Category> CategoryList()
        {
            var listCategory = dal.GetCategoryList();
            return listCategory;
        }
        public void CreateNewCategory(Category category)
        {
            dal.CreateNewCategory(category);
        }

        public Category GetCategoryById(int? id)
        {
            Category category = dal.GetCategoryById(id);
            return category;
        }
        public void UpdateCategory(Category category)
        {
            dal.UpdateCategory(category);
        }
        public void DeleteCategory(int id)
        {
            dal.DeleteCategory(id);
        }
    }
}
