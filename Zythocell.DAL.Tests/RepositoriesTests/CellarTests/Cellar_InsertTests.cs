using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.DAL.Context;
using Zythocell.DAL.Entities;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL.Tests.RepositoriesTests.CellarTests
{
    [TestClass]
    public class Cellar_InsertTests
    {
        [TestMethod]
        public void InsertCellar_Correct()
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
                Alcohol = 9,
                IsDeleted = false
            };

            var addedBeverage = BRepo.Insert(beverage);
            BRepo.Save();

            var user = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

            var cellar = new Cellar
            {
                Age = DateTime.Now.AddDays(-50),
                BeverageId = addedBeverage.Id,
                UserId = user,
                Date = DateTime.Now,
                Quantity = 16
            };

            var result = CRepo.Insert(cellar);
            CRepo.Save();

            Assert.AreEqual(1, BRepo.GetAll().Count);
            Assert.AreEqual(user, result.UserId);
            Assert.AreEqual(16, result.Quantity);
        }
    }
}
