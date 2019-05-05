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
    public class ArtTypesController : Controller
    {
        private IArtTypeRepository db = new ArtTypeRepository(new Repositories.SQLContext());

        // GET: ArtTypes
        public async Task<ActionResult> Index()
        {
            return View(db.GetAll());
        }

        // GET: ArtTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtType artType = db.GetById(id);
            if (artType == null)
            {
                return HttpNotFound();
            }
            return View(artType);
        }

        // GET: ArtTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,Name")] ArtType artType)
        {
            if (ModelState.IsValid)
            {
                db.Add(artType);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(artType);
        }

        // GET: ArtTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtType artType = db.GetById(id);
            if (artType == null)
            {
                return HttpNotFound();
            }
            return View(artType);
        }

        // POST: ArtTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,Name")] ArtType artType)
        {
            if (ModelState.IsValid)
            {
                db.Update(artType);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(artType);
        }

        // GET: ArtTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtType artType = db.GetById(id);
            if (artType == null)
            {
                return HttpNotFound();
            }
            return View(artType);
        }

        // POST: ArtTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ArtType artType = db.GetById(id);
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
