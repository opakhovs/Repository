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
using Repository.Viewmodels.ArtifactsViewModels;

namespace Repository.Controllers
{
    public class ArtifactsController : Controller
    {
        private IArtifactRepository db = new ArtifactRepository(new Repositories.SQLContext());

        // GET: Artifacts
        public async Task<ActionResult> Index()
        {
            return View(db.GetAll());
        }

        // GET: Artifacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // GET: Artifacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artifacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DateOfAdding,Version")] CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Artifact artifact = new Artifact() { Version = viewModel.Version, DateOfAdding = viewModel.DateOfAdding };
                db.Add(artifact);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Artifacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // POST: Artifacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArtifactId,DateOfAdding,Version")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                db.Update(artifact);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(artifact);
        }

        // GET: Artifacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // POST: Artifacts/Delete/5
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
