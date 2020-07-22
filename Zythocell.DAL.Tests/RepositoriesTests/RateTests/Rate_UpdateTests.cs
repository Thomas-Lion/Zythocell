using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.Common.IRepositories;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL.Tests.RepositoriesTests.RateTests
{
    [TestClass]
    public class Rate_UpdateTests
    {
        [TestMethod]
        public void UpdateRate_Correct()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            IRateRepository RRepo = new RateRepository(context);

            var beverage = new BeverageTO
            {
                Name = "Orval",
                BeveragType = BeverageType.Beer,
                Color = "Brown",
                Country = "Belgium",
                Productor = "Abbaye d'Orval",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };

            var addedBeverage = BRepo.Insert(beverage);
            BRepo.Save();

            var user = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            var addedRate = RRepo.Insert(rate);
            RRepo.Save();

            addedRate.Comment = "Si seulement c'était le soir";

            RRepo.Update(addedRate);
            RRepo.Save();

            Assert.AreEqual("Si seulement c'était le soir", RRepo.GetById(addedRate.Id).Comment);
        }

        [TestMethod]
        public void UpdateRate_InvalidRating()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            IRateRepository RRepo = new RateRepository(context);

            var beverage = new BeverageTO
            {
                Name = "Orval",
                BeveragType = BeverageType.Beer,
                Color = "Brown",
                Country = "Belgium",
                Productor = "Abbaye d'Orval",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };

            var addedBeverage = BRepo.Insert(beverage);
            BRepo.Save();

            var user = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            var addedRate = RRepo.Insert(rate);
            RRepo.Save();

            addedRate.Rating = -5;

            Assert.ThrowsException<ArgumentException>(() => RRepo.Update(addedRate));
        }
        
        [TestMethod]
        public void UpdateRate_CantUpdateUserId()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            IRateRepository RRepo = new RateRepository(context);

            var beverage = new BeverageTO
            {
                Name = "Orval",
                BeveragType = BeverageType.Beer,
                Color = "Brown",
                Country = "Belgium",
                Productor = "Abbaye d'Orval",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };

            var addedBeverage = BRepo.Insert(beverage);
            BRepo.Save();

            var user1 = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");
            var user2 = new Guid("62FA647C-AD54-4BCC-A860-FFFFFFFFFFFF");

            var rate = new RateTO
            {
                UserId = user1,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            var addedRate = RRepo.Insert(rate);
            RRepo.Save();

            addedRate.UserId = user2;

            Assert.ThrowsException<ArgumentException>(() => RRepo.Update(addedRate));
        }
    }
}
