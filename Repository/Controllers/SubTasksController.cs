using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Repositories;
using Repository.Repositories.Implementations;
using Repository.Repositories.Interfaces;
using Repository.Viewmodels.SubTasksViewModels;

namespace Repository.Controllers
{
    public class SubTasksController : Controller
    {
        private ISubTaskRepository subTaskRep;
        private SQLContext db = new SQLContext();

        public SubTasksController()
        {
            subTaskRep = new SubTaskRepository(db);
        }

        private ISubTaskRepository SubTaskRepository()
        {
            throw new NotImplementedException();
        }

        // GET: SubTasks
        public ActionResult Index()
        {
            return View(db.SubTasks.ToList());
        }

        // GET: SubTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // GET: SubTasks/Create
        public ActionResult Create()
        {
            CreateViewModel viewModel = new CreateViewModel();
           
            var subTasks = subTaskRep.GetAll().Select(c => new SubTask
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.SubTasks = subTasks;

            return View(viewModel);
        }

        // POST: SubTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Name,SubTaskIds")] CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SubTask subTask = new SubTask() { Name = viewModel.Name, Description = viewModel.Description };
            
                var listOfIndexes = viewModel?.SubTaskIds?.ToList();

                if (listOfIndexes != null)
                {
                    subTask.SubTasks.AddRange(listOfIndexes
                    .SelectMany(i => subTaskRep.GetAll()
                    .Where(p => p.Id == i)));
                }

                SubTask newSubTask = subTask;

                db.SubTasks.Add(newSubTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: SubTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // POST: SubTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,SubTaskIds")] SubTask subTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subTask);
        }

        // GET: SubTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // POST: SubTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTask subTask = db.SubTasks.Find(id);
            db.SubTasks.Remove(subTask);
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
