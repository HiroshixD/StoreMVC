using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETStore.Models;
using BLStore;

namespace Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BLCategory category;
        public CategoryController(BLCategory category)
        {
            this.category = category;
        }
        //
        // GET: /Category/
        public ActionResult Index()
        {
            var items = category.GetAllCategories();
            return View(items);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            var item = category.GetCategoryById(id);
            return View(item);
        }

        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.AddCategory(model);
                    category.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            var item = category.GetCategoryById(id);
            return View(item);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.UpdateCategory(model);
                    category.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var item = category.GetCategoryById(id);
                return View(item);
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            var item = category.GetCategoryById(id);
            return View(item);
        }

        //
        // POST: /Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.DeleteCategory(model);
                    category.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                var item = category.GetCategoryById(id);
                return View(item);
            }
        }
    }
}
