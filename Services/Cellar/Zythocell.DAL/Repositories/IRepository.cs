using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.DAL.Repositories
{
    public interface IRepository<E> where E : class
    {
        public E Insert(E entity);
        public E Update(E entity);
        public ICollection<E> GetAll();
        public int Save();
    }
}
