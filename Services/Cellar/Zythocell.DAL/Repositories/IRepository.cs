using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.DAL.Repositories
{
    public interface IRepository<E> where E : class
    {
        public E Insert(E entity);
        public E Update(E entity);
        public E GetById(int Id);
        public ICollection<E> GetAll();
        public bool Delete(E entity);
        public int Save();
    }
}
