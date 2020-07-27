using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Common.Interfaces.IRepositories
{
    public interface IRepository<E> where E : class
    {
        public E Insert(E entity);
        public E Update(E entity);
        public int Save();
        public E GetById(int Id);
    }
}
