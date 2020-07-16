using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public class CellarRepository : ICellarRepository
    {
        public ICollection<Cellar> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cellar> GetByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Cellar Insert(Cellar entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cellar> OrderByRate(Guid userId)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Cellar Update(Cellar entity)
        {
            throw new NotImplementedException();
        }
    }
}
