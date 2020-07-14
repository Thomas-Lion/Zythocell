using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Common.Interface
{
    public interface IRepository<E> where E : class
    {
        public E Insert(E entity);
        public E Update(E entity);
        public E Get(int Id);
        public ICollection<E> GetAll();
        public int Save();
    }
}
