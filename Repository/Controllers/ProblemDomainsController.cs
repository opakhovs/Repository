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
using Repository.Viewmodels.ProblemDomainViewModels;

namespace Repository.Controllers
{
    public class ProblemDomainsController : Controller
    {
        private IProblemDomainRepository db = new ProblemDomainRepository(new Repositories.SQLContext());
        private ISubTaskRepository dbSubTask = new SubTaskRepository(new Repositories.SQLContext());

        // GET: ProblemDomains
        public async Task<ActionResult> Index()
        {
            return View(db.GetAll());
        }

        // GET: ProblemDomains/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            DetailsDomainViewModel model = new DetailsDomainViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDomain problemDomain = db.GetById(id);
            if (problemDomain == null)
            {
                return HttpNotFound();
            }
            model.Name = problemDomain.Name;
            model.Description = problemDomain.Description;
            model.SubTasks = problemDomain.SubTasks;
            model.SubTaskIds = problemDomain.SubTasks.Select(x => x.Id).ToArray();
            return View(model);
        }

        // GET: ProblemDomains/Create
        public ActionResult Create()
        {
            CreateProblemDomainViewModel viewModel = new CreateProblemDomainViewModel();
            var subTasks = dbSubTask.GetAll().Select(c => new SubTask
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.SubTasks = subTasks;
            return View(viewModel);
        }

        // POST: ProblemDomains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProblemDomainViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProblemDomain domain = new ProblemDomain() { Name = model.Name, Description = model.Description };
                int[] listOfIndexes = model.SubTaskIds;
                if( listOfIndexes != null)
                {
                    domain.SubTasks.AddRange(listOfIndexes.ToList()
                    .SelectMany(i => dbSubTask.GetAll()
                    .Where(p => p.Id == i)));
                }

                db.Add(domain);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ProblemDomains/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDomain problemDomain = db.GetById(id);
            if (problemDomain == null)
            {
                return HttpNotFound();
            }
            return View(problemDomain);
        }

        // POST: ProblemDomains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,Name")] ProblemDomain problemDomain)
        {
            if (ModelState.IsValid)
            {
                db.Update(problemDomain);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(problemDomain);
        }

        // GET: ProblemDomains/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDomain problemDomain = db.GetById(id);
            if (problemDomain == null)
            {
                return HttpNotFound();
            }
            return View(problemDomain);
        }

        // POST: ProblemDomains/Delete/5
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
