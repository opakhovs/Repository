using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class ArtTypeRepository : IArtTypeRepository
    {
        private readonly SQLContext db;

        public ArtTypeRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<ArtType> GetAll()
        {
            return db.ArtTypes.ToList();
        }
        public ArtType GetById(int? id)
        {
            return db.ArtTypes.Find(id);
        }
        public void Add(ArtType obj)
        {
            db.ArtTypes.Add(obj);
        }
        public void Update(ArtType obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            ArtType obj = db.ArtTypes.Find(id);
            db.ArtTypes.Remove(obj);
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