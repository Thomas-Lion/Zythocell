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
    public class Rate_InsertTests
    {
        [TestMethod]
        public void InsertRate_Correct()
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

            var user = "62FA647C-AD54-4BCC-A860-E5A2664B019D";

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            var addedRate = RRepo.Insert(rate);
            RRepo.Save();

            Assert.AreEqual("C'est le matin quoi", addedRate.Comment);
            Assert.AreEqual("Orval", BRepo.GetById(addedRate.BeverageId).Name);
        }

        [TestMethod]
        public void InsertRate_Null()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IRateRepository RRepo = new RateRepository(context);

            Assert.ThrowsException<ArgumentNullException>(() => RRepo.Insert(null));
        }

        [TestMethod]
        public void InsertRate_EmptyUserId()
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

            var user = "";

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            Assert.ThrowsException<ArgumentNullException>(() => RRepo.Insert(rate));
        }

        [TestMethod]
        public void InsertRate_NonValidBeverageId()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IRateRepository RRepo = new RateRepository(context);

            var user = "62FA647C-AD54-4BCC-A860-E5A2664B019D";

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = -66,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };

            Assert.ThrowsException<ArgumentNullException>(() => RRepo.Insert(rate));
        }

        [TestMethod]
        public void InsertRate_NegativeRating()
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

            var user = "62FA647C-AD54-4BCC-A860-E5A2664B019D";

            var rate = new RateTO
            {
                UserId = user,
                BeverageId = 66666,
                Rating = -7.5,
                Comment = "C'est le matin quoi"
            };

            Assert.ThrowsException<ArgumentException>(() => RRepo.Insert(rate));
        }
    }
}
