using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class ArtifactRepository : IArtifactRepository
    {
        private readonly SQLContext db;
        
        public ArtifactRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<Artifact> GetAll()
        {
            return db.Artifacts.ToList();
        }
        public Artifact GetById(int? id)
        {
            return db.Artifacts.Find(id);
        }
        public void Add(Artifact obj)
        {
            db.Artifacts.Add(obj);
        } 
        public void Update(Artifact obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Artifact obj = db.Artifacts.Find(id);
            db.Artifacts.Remove(obj);
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