using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL.Tests.RepositoriesTests.RateTests
{
    [TestClass]
    public class Rate_OrderByRateTests
    {
        [TestMethod]
        public void OrderbyRate_Correct()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            IRateRepository RRepo = new RateRepository(context);

            var beverage = new Beverage
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

            var user = new Guid("62FA647C-AD54-4BCC-A860-AAAAAAAAAAAA");

            var rate1 = new Rate
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 5,
                Comment = "C'est le matin quoi"
            };
            var rate2 = new Rate
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 8,
                Comment = "C'est le matin quoi"
            };
            var rate3 = new Rate
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 7.5,
                Comment = "C'est le matin quoi"
            };
            var rate4 = new Rate
            {
                UserId = user,
                BeverageId = addedBeverage.Id,
                Rating = 0,
                Comment = "C'est le matin quoi"
            };

            var added1 = RRepo.Insert(rate1);
            var added2 = RRepo.Insert(rate2);
            var added3 = RRepo.Insert(rate3);
            var added4 = RRepo.Insert(rate4);
            RRepo.Save();

            var expectedList = new List<Rate>();
            expectedList.Add(added2);
            expectedList.Add(added3);
            expectedList.Add(added1);
            expectedList.Add(added4);

            var result = RRepo.OrderByRate(user);

            Assert.IsTrue(expectedList.SequenceEqual(result));
        }

        [TestMethod]
        public void OrderByRate_EmptyGuid()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IRateRepository RRepo = new RateRepository(context);

            var user = new Guid();

            Assert.ThrowsException<ArgumentNullException>(() => RRepo.OrderByRate(user));
        }
    }
}
