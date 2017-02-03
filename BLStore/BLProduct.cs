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
    public class BLProduct
    {
        private readonly Repository<Product> product;
        public BLProduct(Repository<Product> product)
        {
            this.product = product;
        }

        public object GetAllProducts()
        {
            return product.GetAll();
        }

        public object GetProductById(int id)
        {
            return product.GetItemById(id);
        }

        public void AddProduct(Product model)
        {
            product.Add(model);
        }

        public void Save()
        {
            product.Save();
        }

        public void UpdateProduct(Product model)
        {
            product.Edit(model);
        }

        public void DeleteProduct(Product model)
        {
            product.Delete(model);
        }
    }
}
