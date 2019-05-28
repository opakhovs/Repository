using Repository.Repositories.Implementations;
using Repository.Repositories.Interfaces;
using Repository.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Repositories;

namespace Repository.Areas.User.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: User/Projects
        private SQLContext context = new SQLContext();
        private IProjectRepository db;
        private IArtifactRepository dbArtifacts;

        public ProjectsController()
        {
            db = new ProjectRepository(context);
            dbArtifacts = new ArtifactRepository(context);

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
                var project = viewModel.GetModel();
                var listOfIndexes = viewModel?.SelectedIds?.ToList();

                if (listOfIndexes != null)
                {
                    project.Artifacts.AddRange(listOfIndexes
                    .SelectMany(i => dbArtifacts.GetAll()
                    .Where(p => p.ArtifactId == i)));
                }
                db.Add(project);
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