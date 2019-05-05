using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository
    {
        private readonly SQLContext db;

        public RatingRepository(SQLContext db)
        {
            this.db = db;
        }
        public IEnumerable<Rating> GetAll()
        {
            return db.Ratings.ToList();
        }
        public Rating GetById(int? id)
        {
            return db.Ratings.Find(id);
        }
        public void Add(Rating obj)
        {
            db.Ratings.Add(obj);
        }
        public void Update(Rating obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Rating obj = db.Ratings.Find(id);
            db.Ratings.Remove(obj);
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