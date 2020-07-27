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

namespace Zythocell.DAL.Tests.RepositoriesTests.CellarTests
{
    [TestClass]
    public class Cellar_GetByUserTests
    {
        [TestMethod]
        public void GetByUserCellar_Correct()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            ICellarRepository CRepo = new CellarRepository(context);

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

            var cellar1 = new CellarTO
            {
                Age = DateTime.Now.AddDays(-50),
                BeverageId = addedBeverage.Id,
                UserId = user1,
                Date = DateTime.Now,
                Quantity = 32
            };
            var cellar2 = new CellarTO
            {
                Age = DateTime.Now.AddDays(-666),
                BeverageId = addedBeverage.Id,
                UserId = user1,
                Date = DateTime.Now,
                Quantity = 10
            };
            var cellar3 = new CellarTO
            {
                Age = DateTime.Now.AddDays(-15),
                BeverageId = addedBeverage.Id,
                UserId = user2,
                Date = DateTime.Now,
                Quantity = 25
            };
            var cellar4 = new CellarTO
            {
                Age = DateTime.Now.AddDays(-60),
                BeverageId = addedBeverage.Id,
                UserId = user1,
                Date = DateTime.Now,
                Quantity = 3
            };

            CRepo.Insert(cellar1);
            CRepo.Insert(cellar2);
            CRepo.Insert(cellar3);
            CRepo.Insert(cellar4);
            CRepo.Save();

            var result1 = CRepo.GetByUser(user1);
            var result2 = CRepo.GetByUser(user2);

            Assert.AreEqual(3, result1.Count);
            Assert.AreEqual(1, result2.Count);
        }

        [TestMethod]
        public void GetByUserCellar_EmptyList()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            ICellarRepository CRepo = new CellarRepository(context);

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

            var cellar = new CellarTO
            {
                Age = DateTime.Now.AddDays(-50),
                BeverageId = addedBeverage.Id,
                UserId = user1,
                Date = DateTime.Now,
                Quantity = 32
            };


            CRepo.Insert(cellar);
            CRepo.Save();

            var result2 = CRepo.GetByUser(user2);

            Assert.AreEqual(0, result2.Count);
        }

        [TestMethod]
        public void GetByUserCellar_EmptyGuid()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            ICellarRepository CRepo = new CellarRepository(context);

            var user = new Guid();

            Assert.ThrowsException<ArgumentNullException>(() => CRepo.GetByUser(user));
        }
    }
}
