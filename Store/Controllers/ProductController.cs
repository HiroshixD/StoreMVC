using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETStore.Models;
using BLStore;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
       private readonly BLProduct product;
       private readonly BLCategory category;

        public ProductController(BLProduct product, BLCategory category)
        {
            this.product = product;
            this.category = category;
        }
        //
        // GET: /Product/
        public ActionResult Index()
        {
            var item = product.GetAllProducts();
            return View(item);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            var item = product.GetProductById(id);
            return View(item);
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = category.GetAllCategories();
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.AddProduct(model);
                    product.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            var item = product.GetProductById(id);
            return View(item);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.UpdateProduct(model);
                    product.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                var item = product.GetProductById(id);
                return View(item);
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            var item = product.GetProductById(id);
            return View(item);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.DeleteProduct(model);
                    product.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                var item = product.GetProductById(id);
                return View(item);
            }
        }
    }
}
