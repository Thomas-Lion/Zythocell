using Microsoft.EntityFrameworkCore;
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

        public Cellar GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var beverage = context.Cellars.AsNoTracking()
                                          .FirstOrDefault(x => x.Id == Id);
            if (beverage == null)
            {
                throw new NullReferenceException();
            }
            return beverage;
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
            if (entity.Quantity <= 0)
            {
                throw new ArgumentException();
            }
            
            var result = context.Cellars.Add(entity);
            return result.Entity;
        }

        public ICollection<Cellar> OrderByDate(Guid userId)
        {
            var cellars = context.Cellars.OrderBy(x => x.Date)
                                         .Select(x => x)
                                         .ToList();
            return cellars;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Cellar Update(Cellar entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Quantity < 0)
                throw new ArgumentException();

            if (entity.UserId != GetById(entity.Id).UserId)
            {
                throw new ArgumentException();
            }

            context.Cellars.Attach(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
