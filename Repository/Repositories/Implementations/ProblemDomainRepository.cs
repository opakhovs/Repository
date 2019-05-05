using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class ProblemDomainRepository : IProblemDomainRepository
    {
        private readonly SQLContext db;

        public ProblemDomainRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<ProblemDomain> GetAll()
        {
            return db.ProblemDomains.ToList();
        }
        public ProblemDomain GetById(int? id)
        {
            return db.ProblemDomains.Find(id);
        }
        public void Add(ProblemDomain obj)
        {
            db.ProblemDomains.Add(obj);
        }
        public void Update(ProblemDomain obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            ProblemDomain obj = db.ProblemDomains.Find(id);
            db.ProblemDomains.Remove(obj);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}