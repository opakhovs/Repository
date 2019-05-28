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
using Repository.Repositories;

namespace Repository.Controllers
{
    public class ProjectsController : Controller
    {
        private SQLContext context = new SQLContext();
        private IProjectRepository db;
        private IArtifactRepository dbArtifacts; 

        public ProjectsController()
        {
            db = new ProjectRepository(context);
            dbArtifacts= new ArtifactRepository(context);

        }

        // GET: Projects
        public async Task<ActionResult> Index()
        {
            List<ProjectViewModel> list = new List<ProjectViewModel>();
            foreach (var i in db.GetAll())
            {
                list.Add(new ProjectViewModel(i));
            }

            return View(list);
        }

        // GET: Projects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project Project = db.GetById(id);
            if (Project == null)
            {
                return HttpNotFound();
            }
            return View(new ProjectViewModel(Project));
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Artifacts = dbArtifacts.GetAll().Select(c => new Artifact
            {
                ArtifactId = c.ArtifactId,
                Properties = c.Properties
            }).ToList();
            return View(viewModel);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Projects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project Project = db.GetById(id);
            if (Project == null)
            {
                return HttpNotFound();
            }
            return View(new ProjectViewModel(Project));
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Update(viewModel.GetModel());
                db.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Projects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project Project = db.GetById(id);
            if (Project == null)
            {
                return HttpNotFound();
            }
            return View(new ProjectViewModel(Project));
        }

        // POST: Projects/Delete/5
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
