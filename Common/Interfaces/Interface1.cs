using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T Create(T obj);
        T Retrieve(int id);
        T Retrieve(string id);
        List<T> RetrieveAll();
        void Update(T obj);
        void Delete(int id);
        void Delete(string id);
    }
}
