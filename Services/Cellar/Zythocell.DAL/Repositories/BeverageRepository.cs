using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.Common.Interfaces.IRepositories;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Extensions;

namespace Zythocell.DAL.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly ZythocellContext context;

        public BeverageRepository(ZythocellContext context)
        {
            this.context = context;
        }
        public BeverageTO GetById(int Id)
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
            return beverage.ToTO();
        }

        public ICollection<BeverageTO> GetAll()
        {
            var beverages = context.Beverages.Where(x => x.IsDeleted == false)
                                             .Select(x => x.ToTO())
                                             .ToList();
            return beverages;
        }

        public BeverageTO Insert(BeverageTO entity)
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
            var result = context.Beverages.Add(entity.ToEF());
            return result.Entity.ToTO();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public BeverageTO Update(BeverageTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Size <= 0 || entity.Alcohol < 0)
                throw new ArgumentException();

            var updated = context.Beverages.FirstOrDefault(e => e.Id == entity.Id);
            if (updated != default)
            {
                updated.UpdateFromDetached(entity.ToEF());
            }
            Save();

            return context.Beverages.Update(updated).Entity.ToTO();
        }

        public bool Delete(BeverageTO entity)
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
