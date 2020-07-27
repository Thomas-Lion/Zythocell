using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.Common.Interfaces.IRepositories;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL.Tests.RepositoriesTests.RateTests
{
    [TestClass]
    public class Rate_GetByUserTests
    {
        [TestMethod]
        public void GetByUserRate_Correct()
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

            var user1 = new Guid("62FA647C-AD54-4BCC-A860-AAAAAAAAAAAA");
            var user2 = new Guid("62FA647C-AD54-4BCC-A860-FFFFFFFFFFFF");

            var rate1 = new RateTO
            {
                UserId = user1,
                BeverageId = addedBeverage.Id,
                Rating = 5,
                Comment = "C'est le matin quoi"
            };
            var rate2 = new RateTO
            {
                UserId = user1,
                BeverageId = addedBeverage.Id,
                Rating = 8,
                Comment = "C'est le matin quoi"
            };
            var rate3 = new RateTO
            {
                UserId = user1,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };
            var rate4 = new RateTO
            {
                UserId = user2,
                BeverageId = addedBeverage.Id,
                Rating = 0,
                Comment = "C'est le matin quoi"
            };

            RRepo.Insert(rate1);
            RRepo.Insert(rate2);
            RRepo.Insert(rate3);
            RRepo.Insert(rate4);
            RRepo.Save();

            var result1 = RRepo.GetByUser(user1);
            var result2 = RRepo.GetByUser(user2);

            Assert.AreEqual(3, result1.Count);
            Assert.AreEqual(1, result2.Count);
        }

        [TestMethod]
        public void GetByUserRate_EmptyGuid()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IRateRepository RRepo = new RateRepository(context);

            var user = new Guid();

            Assert.ThrowsException<ArgumentNullException>(() => RRepo.GetByUser(user));
        }

        [TestMethod]
        public void GetByUserRate_EmptyList()
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

            var user1 = new Guid("62FA647C-AD54-4BCC-A860-AAAAAAAAAAAA");
            var user2 = new Guid("62FA647C-AD54-4BCC-A860-FFFFFFFFFFFF");

            var rate = new RateTO
            {
                UserId = user1,
                BeverageId = addedBeverage.Id,
                Rating = 5,
                Comment = "C'est le matin quoi"
            };

            RRepo.Insert(rate);
            RRepo.Save();

            var result2 = RRepo.GetByUser(user2);

            Assert.AreEqual(0, result2.Count);
        }
    }
}
