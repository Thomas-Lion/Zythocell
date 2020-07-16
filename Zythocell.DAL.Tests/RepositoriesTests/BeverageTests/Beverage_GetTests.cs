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

namespace Zythocell.DAL.Tests.RepositoriesTests.BeverageTests
{
    [TestClass]
    public class Beverage_GetTests
    {
        [TestMethod]
        public void GetById_CorrectId()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);

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

            var added = BRepo.Insert(beverage);
            BRepo.Save();

            var result = BRepo.GetById(added.Id);

            Assert.AreEqual("Orval", result.Name);
        }

        [TestMethod]
        public void GetById_NothingToGet()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);

            Assert.ThrowsException<ArgumentException>(() => BRepo.GetById(-666));
        }
    }
}
