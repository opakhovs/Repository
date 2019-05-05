using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly SQLContext db;

        public TagRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }
        public Tag GetById(int? id)
        {
            return db.Tags.Find(id);
        }
        public void Add(Tag obj)
        {
            db.Tags.Add(obj);
        }
        public void Update(Tag obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Tag obj = db.Tags.Find(id);
            db.Tags.Remove(obj);
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