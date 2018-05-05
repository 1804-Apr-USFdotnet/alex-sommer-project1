using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurauntDataLayer;

namespace RestaurauntDataAccess
{
    public interface ICrud<T> where T : RestaurauntDataEntities
    {
        T GetById(object ID);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
