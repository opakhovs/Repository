using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Implementations;

namespace Repository.Controllers
{
    public class TagsController : Controller
    {
        private ITagRepository db = new TagRepository(new Repositories.SQLContext());

        // GET: Tags
        public async Task<ActionResult> Index()
        {
            return View(db.GetAll());
        }

        // GET: Tags/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.GetById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,Name,TagUsage")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Add(tag);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tags/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.GetById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,Name,TagUsage")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Update(tag);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.GetById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
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
