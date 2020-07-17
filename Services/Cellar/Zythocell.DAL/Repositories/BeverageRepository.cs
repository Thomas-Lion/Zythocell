using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly ZythocellContext context;

        public BeverageRepository(ZythocellContext context)
        {
            this.context = context;
        }
        public Beverage GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var beverage = context.Beverages.AsNoTracking()
                                            .FirstOrDefault(x => x.Id == Id);
            if (beverage == null)
            {
                throw new NullReferenceException();
            }
            return beverage;
        }

        public ICollection<Beverage> GetAll()
        {
            var beverages = context.Beverages.Where(x => x.IsDeleted == false)
                                             .Select(x => x)
                                             .ToList();
            return beverages;
        }

        public Beverage Insert(Beverage entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            if (entity.Size <= 0 || entity.Alcohol < 0)
            {
                throw new ArgumentException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }
            var result = context.Beverages.Add(entity);
            return result.Entity;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Beverage Update(Beverage entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Size <= 0 || entity.Alcohol < 0)
                throw new ArgumentException();

            context.Beverages.Attach(entity).State = EntityState.Modified;

            return entity;
        }

        public bool Delete(Beverage entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException(nameof(entity));
            }

            if (entity.IsDeleted)
            {
                throw new ArgumentException(nameof(entity));
            }

            entity.IsDeleted = true;
            var result = Update(entity);

            return result != null;
        }
    }
}
