using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public class CellarRepository : ICellarRepository
    {
        private readonly ZythocellContext context;

        public CellarRepository(ZythocellContext context)
        {
            this.context = context;
        }
        public ICollection<Cellar> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cellar> GetByUser(Guid userId)
        {
            var cellars = context.Cellars.Where(x => x.UserId == userId)
                                         .Select(x => x)
                                         .ToList();
            return cellars;
        }

        public Cellar Insert(Cellar entity)
        {
            if (entity is null || entity.UserId == Guid.Empty || entity.BeverageId <= 0)
            {
                throw new ArgumentNullException();
            }
            
            var result = context.Cellars.Add(entity);
            return result.Entity;
        }

        public ICollection<Cellar> OrderByRate(Guid userId)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Cellar Update(Cellar entity)
        {
            throw new NotImplementedException();
        }
    }
}
