using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVCStore.Interfaces;
using ETStore.Models;
using DataStore.Repo;


namespace BLStore
{
    public class BLCategory
    {
        private readonly Repository<Category> category;
        public BLCategory(Repository<Category> category)
        {
            this.category = category;
        }



        public object GetAllCategories()
        {
            return category.GetAll();
        }

        public object GetCategoryById(int id)
        {
            return category.GetItemById(id);
        }

        public void AddCategory(Category model)
        {
            category.Add(model);
        }

        public void Save()
        {
            category.Save();
        }

        public void UpdateCategory(Category model)
        {
            category.Edit(model);
        }

        public void DeleteCategory(Category model)
        {
            category.Delete(model);
        }
    }
}
