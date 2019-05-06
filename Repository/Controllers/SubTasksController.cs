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
    public class SubTasksController : Controller
    {
        //private ISubTaskRepository db = new SubTaskRepository(new Repositories.SQLContext());

        //// GET: SubTasks
        //public async Task<ActionResult> Index()
        //{
        //    return View(db.GetAll());
        //}

        //// GET: SubTasks/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubTask subTask = db.GetById(id);
        //    if (subTask == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subTask);
        //}

        //// GET: SubTasks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SubTasks/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Description,Name")] SubTask subTask)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Add(subTask);
        //        db.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View(subTask);
        //}

        //// GET: SubTasks/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubTask subTask = db.GetById(id);
        //    if (subTask == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subTask);
        //}

        //// POST: SubTasks/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Description,Name")] SubTask subTask)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Update(subTask);
        //        db.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(subTask);
        //}

        //// GET: SubTasks/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubTask subTask = db.GetById(id);
        //    if (subTask == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subTask);
        //}

        //// POST: SubTasks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    db.Delete(id);
        //    db.Save();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
