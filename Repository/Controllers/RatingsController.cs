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
    public class RatingsController : Controller
    {
        private IRatingRepository db = new RatingRepository(new Repositories.SQLContext());

        // GET: Ratings
        public async Task<ActionResult> Index()
        {
            List<RatingViewModel> list = new List<RatingViewModel>();
            foreach (var i in db.GetAll())
            {
                list.Add(new RatingViewModel(i));
            }

            return View(list);
        }

        // GET: Ratings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating Rating = db.GetById(id);
            if (Rating == null)
            {
                return HttpNotFound();
            }
            return View(new RatingViewModel(Rating));
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Ratings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating Rating = db.GetById(id);
            if (Rating == null)
            {
                return HttpNotFound();
            }
            return View(new RatingViewModel(Rating));
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Update(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Ratings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating Rating = db.GetById(id);
            if (Rating == null)
            {
                return HttpNotFound();
            }
            return View(new RatingViewModel(Rating));
        }

        // POST: Ratings/Delete/5
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
