using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class ArtifactTypeRepository : IArtifactPropertyRepository
    {
        private readonly SQLContext db;

        public ArtifactTypeRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<ArtifactProperty> GetAll()
        {
            return db.ArtifactProperties.ToList();
        }
        public ArtifactProperty GetById(int? id)
        {
            return db.ArtifactProperties.Find(id);
        }
        public void Add(ArtifactProperty obj)
        {
            db.ArtifactProperties.Add(obj);
        }
        public void Update(ArtifactProperty obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            ArtifactProperty obj = db.ArtifactProperties.Find(id);
            db.ArtifactProperties.Remove(obj);
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