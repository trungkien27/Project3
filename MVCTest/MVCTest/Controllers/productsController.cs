using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCTest;

namespace MVCTest.Controllers
{
    public class productsController : Controller
    {
        private PrrojectSem3Entities db = new PrrojectSem3Entities();

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.category);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.category, "id", "categoryName");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,category_id,price,thumbnail,size,weight,note,created_at,update_at")] products products, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Image"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                db.products.Add(new products
                {
                    id = products.id,
                    name = products.name,
                    category_id = products.category_id,
                    price = products.price,
                    thumbnail = "~/Image/" + file.FileName,
                    size = products.size,
                    weight = products.weight,
                    note = products.note,
                    created_at = DateTime.Now,
                    update_at = DateTime.Now

                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.category_id = new SelectList(db.category, "id", "categoryName", products.category_id);
            return View(products);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.category, "id", "categoryName", products.category_id);
            return View(products);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(products products, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                
                string path = Path.Combine(Server.MapPath("~/Image"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                products.thumbnail = "~/Image/" + file.FileName;
                products.created_at = 
                products.update_at = DateTime.Now;  
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.category, "id", "categoryName", products.category_id);
            return View(products);
        }

        // GET: products/Delete/5
       /* public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }*/

        // POST: products/Delete/5
        
        public ActionResult Delete(int id)
        {
            products products = db.products.Find(id);
            db.products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
