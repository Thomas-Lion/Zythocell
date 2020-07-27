using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Interfaces;
using Zythocell.Common.Interfaces.IUsesCases;
using Zythocell.Common.TransferObject;
using Zythocell.DAL;

namespace Zythocell.BLL.UsesCases
{
    public class CellarUsesCases : ICellarUsesCases
    {
        private readonly IUnitOfWork UnitOfWork;

        public CellarUsesCases(IUnitOfWork unitOfWork) 
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentException("UOW not initialazed properly");
        }

        public CellarTO AdditionToCellar(CellarTO cellar)
        {
            if (cellar is null)
                throw new ArgumentNullException("The cellar cannot be null");
            if (cellar.Id != 0)
                throw new ArgumentException("The cellar cannot have a id");
            if (cellar.Quantity < 0)
                throw new ArgumentException("The cellar cannot have a negative quantity of beverages");
            if (cellar.BeverageId <= 0)
                throw new ArgumentNullException("The cellar must have a valid beverage associated");

            return UnitOfWork.CellarRepository.Insert(cellar);
        }

        public BeverageTO CreateANewBeverage(BeverageTO beverage)
        {
            if (beverage is null)
                throw new ArgumentNullException("The beverage cannot be null");
            if (beverage.Id != 0)
                throw new ArgumentException("The beverage cannot have an id");
            if (beverage.Alcohol < 0)
                throw new ArgumentException("The beverage cannot have a negative alcohol degree");
            if (beverage.Size < 0)
                throw new ArgumentException("The beverage cannot have a negative size");
            
            return UnitOfWork.BeverageRepository.Insert(beverage);
        }

        public RateTO CreateANewRating(RateTO rate)
        {
            if (rate.UserId == Guid.Empty)
                throw new ArgumentNullException("You must be connected to add a rating");
            if (rate.Id != 0)
                throw new ArgumentException("The rate cannot have an id");
            if (rate.BeverageId <= 0 )
                throw new ArgumentNullException("The rating must have a valid beverage associated");
            if (rate.Rating < 0)
                throw new ArgumentNullException("The rating cannot be negative");

            return UnitOfWork.RateRepository.Insert(rate);
        }

        public BeverageTO GetABeverage(string name)
        {
            throw new NotImplementedException();
        }

        public List<CellarTO> GetAllCellar(Guid user)
        {
            if (user == Guid.Empty)
                throw new ArgumentNullException("You must be connected to see your cellar");

            return UnitOfWork.CellarRepository.GetByUser(user);
        }

        public List<RateTO> GetAllRating(Guid user)
        {
            if (user == Guid.Empty)
                throw new ArgumentNullException("You must be connected to see your ratings");

            return UnitOfWork.RateRepository.GetByUser(user);
        }

        public List<CellarTO> SearchEntry(string search)
        {
            throw new NotImplementedException();
        }

        public BeverageTO UpdateABeverage(BeverageTO beverage)
        {
            if (beverage is null)
                throw new ArgumentNullException("The beverage cannot be null");
            if (beverage.Alcohol < 0)
                throw new ArgumentException("The beverage cannot have a negative alcohol degree");
            if (beverage.Size < 0)
                throw new ArgumentException("The beverage cannot have a negative size");

            return UnitOfWork.BeverageRepository.Update(beverage);
        }

        public CellarTO UpdateAnEntry(CellarTO cellar)
        {
            if (cellar is null)
                throw new ArgumentNullException("The cellar cannot be null");
            if (cellar.Quantity < 0)
                throw new ArgumentException("The cellar cannot have a negative quantity of beverages");
            if (cellar.BeverageId <= 0)
                throw new ArgumentNullException("The cellar must have a valid beverage associated");

            return UnitOfWork.CellarRepository.Update(cellar);
        }

        public RateTO UpdateARating(RateTO rating)
        {
            if (rating.UserId == Guid.Empty)
                throw new ArgumentNullException("You must be connected to add a rating");
            if (rating.BeverageId <= 0)
                throw new ArgumentNullException("The rating must have a valid beverage associated");
            if (rating.Rating < 0)
                throw new ArgumentNullException("The rating cannot be negative");

            return UnitOfWork.RateRepository.Update(rating);
        }
    }
}
