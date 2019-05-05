using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly SQLContext db;

        public ProjectRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<Project> GetAll()
        {
            return db.Projects.ToList();
        }
        public Project GetById(int? id)
        {
            return db.Projects.Find(id);
        }
        public void Add(Project obj)
        {
            db.Projects.Add(obj);
        }
        public void Update(Project obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Project obj = db.Projects.Find(id);
            db.Projects.Remove(obj);
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