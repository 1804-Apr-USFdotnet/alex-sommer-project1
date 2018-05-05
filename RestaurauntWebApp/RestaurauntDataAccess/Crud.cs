using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurauntDataLayer;

namespace RestaurauntDataAccess
{
    class Crud<T> : ICrud<T> where T : RestaurauntDataEntities
    {
        private readonly RestaurauntDataEntities _context;
        //private IDbSet<T> _entities;

            public Crud(RestaurauntDataEntities context)
        {
            this._context = context;
        }

        public IQueryable<T> Table => throw new NotImplementedException();

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(object ID)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
