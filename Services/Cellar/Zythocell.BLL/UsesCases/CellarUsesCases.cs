using System;
using System.Collections.Generic;
using System.Linq;
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
            this.UnitOfWork = unitOfWork ?? throw new ArgumentException("UOW not initialazed properly");
        }

        public CellarTO AdditionToCellar(CellarTO cellar)
        {
            if (cellar is null)
                throw new ArgumentNullException("The cellar cannot be null");
            if (cellar.UserId == Guid.Empty)
                throw new ArgumentNullException("You must be connected to add a cellar entry");
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
            beverage.IsDeleted = false;
            return UnitOfWork.BeverageRepository.Insert(beverage);
        }

        public RateTO CreateANewRating(RateTO rate)
        {
            if (rate is null)
                throw new ArgumentNullException("The rate cannot be null");
            if (rate.Id != 0)
                throw new ArgumentException("The rate cannot have an id");
            if (rate.UserId == Guid.Empty)
                throw new ArgumentNullException("You must be connected to add a rating");
            if (rate.BeverageId <= 0)
                throw new ArgumentNullException("The rating must have a valid beverage associated");
            if (rate.Rating < 0)
                throw new ArgumentException("The rating cannot be negative");

            return UnitOfWork.RateRepository.Insert(rate);
        }

        public bool DeleteARating(Guid user, RateTO rating)
        {
            if (rating is null)
                throw new ArgumentNullException("Can't delete nothing");
            if (user == Guid.Empty)
                throw new ArgumentNullException("You must be connected to delete a rating");
            if (rating.IsDeleted)
                throw new ArgumentException("You cannot delete something already deleted");

            if (rating.UserId == user)
                return UnitOfWork.RateRepository.Delete(rating);

            return false;
        }

        public BeverageTO GetABeverage(string name)
        {
            throw new NotImplementedException();
        }

        public BeverageTO GetABeverage(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Please use a valid Id");
            return UnitOfWork.BeverageRepository.GetById(id);
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

            /*Must keep
            Depends on Repo method
             */
            //var result = new List<RateTO>();
            //List<RateTO> allRating = UnitOfWork.RateRepository.GetAll().Where(r => r.UserId == user).ToList();

            //foreach (var item in allRating)
            //{
            //    result.Add(item);
            //}
            //return result;
        }

        public CellarTO GetSpecificCellar(Guid user, int id)
        {
            if (user == Guid.Empty)
                throw new ArgumentNullException("You must be connected to see your cellar");
            if (id <= 0)
                throw new ArgumentException("Please use a valid Id");

            var result = UnitOfWork.CellarRepository.GetById(id);
            if (user == result.UserId)
                return result;

            throw new ArgumentException("Check if you're correctly connected or if the Id is correct");
        }

        public RateTO GetSpecificRate(Guid user, int id)
        {
            if (user == Guid.Empty)
                throw new ArgumentNullException("You must be connected to see your cellar");
            if (id <= 0)
                throw new ArgumentException("Please use a valid Id");

            var allRate = UnitOfWork.RateRepository.GetByUser(user);

            foreach (var rate in allRate)
            {
                if (rate.CellarId == id)
                    return rate;
            }

            throw new ArgumentException("Check if you're correctly connected or if the Id is correct");
        }

        public CellarTO MinusOne(CellarTO cellar)
        {
            if (cellar.Quantity >= 1)
                cellar.Quantity += -1;

            return UpdateAnEntry(cellar);
        }

        public CellarTO PlusOne(CellarTO cellar)
        {
            if (cellar.Quantity >= 0)
                cellar.Quantity += 1;

            return UpdateAnEntry(cellar);
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
            if (rating is null)
                throw new ArgumentNullException("The rating cannot be null");
            if (rating.BeverageId <= 0)
                throw new ArgumentException("The rating must have a valid beverage associated");
            if (rating.Rating < 0)
                throw new ArgumentException("The rating cannot be negative");

            return UnitOfWork.RateRepository.Update(rating);
        }
    }
}
