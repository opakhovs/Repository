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
using Repository.Viewmodels;

namespace Repository.Controllers
{
    public class ArtTypesController : Controller
    {
        private IArtTypeRepository db = new ArtTypeRepository(new Repositories.SQLContext());

        // GET: ArtTypes
        public async Task<ActionResult> Index()
        {
            List<ArtTypeViewModel> list = new List<ArtTypeViewModel>();
            foreach(var i in db.GetAll())
            {
                list.Add(new ArtTypeViewModel(i));
            }
            
            return View(list);
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
            return View(new ArtTypeViewModel(artType));
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
        public async Task<ActionResult> Create(ArtTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
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
            return View(new ArtTypeViewModel(artType));
        }

        // POST: ArtTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ArtTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Update(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
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
            return View(new ArtTypeViewModel(artType));
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
