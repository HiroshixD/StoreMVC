using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETStore.Models;
using SVCStore.Interfaces;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> product;
        private readonly IRepository<Category> category;

        public ProductController(IRepository<Product> product, IRepository<Category> category)
        {
            this.product = product;
            this.category = category;
        }
        //
        // GET: /Product/
        public ActionResult Index()
        {
            var items = product.GetAll();
            return View(items);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            var item = product.GetItemById(id);
            return View(item);
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(category.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Add(model);
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
            var item = product.GetItemById(id);
            return View(item);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Edit(model);
                    product.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var item = product.GetItemById(id);
                return View(item);
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            var item = product.GetItemById(id);
            return View(item);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Delete(model);
                    product.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var item = product.GetItemById(id);
                return View(item);
            }
        }
    }
}
