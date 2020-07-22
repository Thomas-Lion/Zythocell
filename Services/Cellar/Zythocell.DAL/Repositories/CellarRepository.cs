using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.Common.IRepositories;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Extensions;

namespace Zythocell.DAL.Repositories
{
    public class CellarRepository : ICellarRepository
    {
        private readonly ZythocellContext context;

        public CellarRepository(ZythocellContext context)
        {
            this.context = context;
        }

        public CellarTO GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var cellar = context.Cellars.AsNoTracking()
                                          .FirstOrDefault(x => x.Id == Id);
            if (cellar == null)
            {
                throw new NullReferenceException();
            }
            return cellar.ToTO();
        }

        public ICollection<CellarTO> GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            var cellars = context.Cellars.Where(x => x.UserId == userId)
                                         .Select(x => x.ToTO())
                                         .ToList();
            return cellars;
        }

        public CellarTO Insert(CellarTO entity)
        {
            if (entity is null || entity.UserId == Guid.Empty || entity.BeverageId <= 0)
            {
                throw new ArgumentNullException();
            }
            if (entity.Quantity <= 0)
            {
                throw new ArgumentException();
            }

            var result = context.Cellars.Add(entity.ToEF());
            return result.Entity.ToTO();
        }

        /*
         * Order By Ascending Older to Newer
         */
        public List<CellarTO> OrderByDate(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            var cellars = context.Cellars.OrderBy(x => x.Date)
                                         .Select(x => x.ToTO())
                                         .ToList();
            return cellars;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public CellarTO Update(CellarTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Quantity < 0)
                throw new ArgumentException();

            if (entity.UserId != GetById(entity.Id).UserId)
            {
                throw new ArgumentException();
            }

            var updated = context.Cellars.FirstOrDefault(e => e.Id == entity.Id);
            if (updated != default)
            {
                updated.UpdateFromDetached(entity.ToEF());
            }
            Save();

            return context.Cellars.Update(updated).Entity.ToTO();
        }
    }
}
