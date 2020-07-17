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

namespace Zythocell.DAL.Tests.RepositoriesTests.CellarTests
{
    [TestClass]
    public class Cellar_OrderByDateTests
    {
        [TestMethod]
        public void OrderByDateCellar_Correct()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);
            ICellarRepository CRepo = new CellarRepository(context);

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

            var cellar4 = new Cellar
            {
                Age = DateTime.Now.AddDays(-50),
                BeverageId = addedBeverage.Id,
                UserId = user,
                Date = DateTime.Now,
                Quantity = 32
            };
            var cellar3 = new Cellar
            {
                Age = DateTime.Now.AddDays(-666),
                BeverageId = addedBeverage.Id,
                UserId = user,
                Date = DateTime.Now.AddHours(12),
                Quantity = 10
            };
            var cellar2 = new Cellar
            {
                Age = DateTime.Now.AddDays(-15),
                BeverageId = addedBeverage.Id,
                UserId = user,
                Date = DateTime.Now.AddDays(60),
                Quantity = 25
            };
            var cellar1 = new Cellar
            {
                Age = DateTime.Now.AddDays(-60),
                BeverageId = addedBeverage.Id,
                UserId = user,
                Date = DateTime.Now.AddDays(365),
                Quantity = 3
            };

            var added1 = CRepo.Insert(cellar1);
            var added2 = CRepo.Insert(cellar2);
            var added3 = CRepo.Insert(cellar3);
            var added4 = CRepo.Insert(cellar4);
            CRepo.Save();

            var expectedList = new List<Cellar>();
            expectedList.Add(added4);
            expectedList.Add(added3);
            expectedList.Add(added2);
            expectedList.Add(added1);

            var result = CRepo.OrderByDate(user);

            Assert.IsTrue(expectedList.SequenceEqual(result));
        }
    }
}
