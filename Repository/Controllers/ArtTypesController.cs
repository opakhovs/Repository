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

namespace Repository.Controllers
{
    public class ArtTypesController : Controller
    {
        private RepositoryContext db = new RepositoryContext();

        // GET: ArtTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.ArtTypes.ToListAsync());
        }

        // GET: ArtTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtType artType = await db.ArtTypes.FindAsync(id);
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
                db.ArtifactProperties.Add(artType);
                await db.SaveChangesAsync();
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
            ArtType artType = await db.ArtTypes.FindAsync(id);
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
                db.Entry(artType).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
            ArtType artType = await db.ArtTypes.FindAsync(id);
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
            ArtType artType = await db.ArtTypes.FindAsync(id);
            db.ArtifactProperties.Remove(artType);
            await db.SaveChangesAsync();
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
