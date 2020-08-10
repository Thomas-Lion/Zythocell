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
    public class RateRepository : IRateRepository
    {
        private readonly ZythocellContext context;

        public RateRepository(ZythocellContext context)
        {
            this.context = context;
        }

        public bool Delete(RateTO rate)
        {
            if (rate is null)
                throw new ArgumentNullException(nameof(rate));
            if (rate.Id <= 0)
                throw new ArgumentException(nameof(rate));
            if (rate.IsDeleted)
                throw new ArgumentException(nameof(rate));

            rate.IsDeleted = true;
            rate.CellarId = 0;
            return Update(rate).IsDeleted;
        }

        public List<RateTO> GetAll()
        {
            var result = context.Rates.Select(x => x.ToTO()).ToList();
            return result;
        }

        public RateTO GetById(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException();
            var rate = context.Rates.AsNoTracking()
                                    .FirstOrDefault(x => x.Id == Id);
            if (rate == null)
                throw new NullReferenceException();

            return rate.ToTO();
        }

        public List<RateTO> GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException();

            var rates = context.Rates.Where(x => x.UserId == userId)
                                     .Select(x => x.ToTO())
                                     .ToList();
            return rates;
        }

        public RateTO Insert(RateTO entity)
        {
            if (entity is null || entity.UserId == Guid.Empty || entity.BeverageId <= 0)
                throw new ArgumentNullException();
            if (entity.Rating < 0)
                throw new ArgumentException();

            if (entity.Id != 0)
                return entity;

            var result = context.Rates.Add(entity.ToEF());

            return result.Entity.ToTO();
        }

        /*
         *  Order By Descending Best to Bad
         */
        public List<RateTO> OrderByRate(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException();

            var rates = context.Rates.OrderByDescending(x => x.Rating)
                                     .Select(x => x.ToTO())
                                     .ToList();
            return rates;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public RateTO Update(RateTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0 || entity.Rating < 0)
                throw new ArgumentException();

            //check if userId is updated by looking the id of the entity 
            // test entity.id update and see if this if is triggered
            if (entity.UserId != GetById(entity.Id).UserId)
                throw new ArgumentException();
            
            var updated = context.Rates.FirstOrDefault(e => e.Id == entity.Id);

            if (updated != default)
                updated.UpdateFromDetached(entity.ToEF());

            Save();

            return context.Rates.Update(updated).Entity.ToTO();
        }
    }
}
