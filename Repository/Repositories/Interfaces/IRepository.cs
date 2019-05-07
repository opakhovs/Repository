using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{

    public interface IDataSource<out T>:IDisposable where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
    }

    public interface IRepository<T>:IDisposable where T:class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
