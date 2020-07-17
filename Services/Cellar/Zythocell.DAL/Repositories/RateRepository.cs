using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ZythocellContext context;

        public RateRepository(ZythocellContext context)
        {
            this.context = context;
        }

        public Rate GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var rate = context.Rates.AsNoTracking()
                                    .FirstOrDefault(x => x.Id == Id);
            if (rate == null)
            {
                throw new NullReferenceException();
            }
            return rate;
        }

        public ICollection<Rate> GetByUser(Guid userId)
        {
            var rates = context.Rates.Where(x => x.UserId == userId)
                                     .Select(x => x)
                                     .ToList();
            return rates;
        }

        public Rate Insert(Rate entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            if (entity.Rating < 0)
            {
                throw new ArgumentException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }
            var result = context.Rates.Add(entity);
            return result.Entity;
        }

        public ICollection<Rate> OrderByRate(Guid userId)
        {
            var rates = context.Rates.OrderBy(x => x.Rating)
                                     .Select(x => x)
                                     .ToList();
            return rates;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Rate Update(Rate entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Rating < 0)
                throw new ArgumentException();

            if (entity.UserId != GetById(entity.Id).UserId)
            {
                throw new ArgumentException();
            }

            context.Rates.Attach(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
