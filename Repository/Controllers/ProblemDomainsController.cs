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
    public class ProblemDomainsController : Controller
    {
        private RepositoryContext db = new RepositoryContext();

        // GET: ProblemDomains
        public async Task<ActionResult> Index()
        {
            return View(await db.ProblemDomains.ToListAsync());
        }

        // GET: ProblemDomains/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDomain problemDomain = await db.ProblemDomains.FindAsync(id);
            if (problemDomain == null)
            {
                return HttpNotFound();
            }
            return View(problemDomain);
        }

        // GET: ProblemDomains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemDomains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,Name")] ProblemDomain problemDomain)
        {
            if (ModelState.IsValid)
            {
                db.ArtifactProperties.Add(problemDomain);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(problemDomain);
        }

        // GET: ProblemDomains/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDomain problemDomain = await db.ProblemDomains.FindAsync(id);
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
                db.Entry(problemDomain).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
            ProblemDomain problemDomain = await db.ProblemDomains.FindAsync(id);
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
            ProblemDomain problemDomain = await db.ProblemDomains.FindAsync(id);
            db.ArtifactProperties.Remove(problemDomain);
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
