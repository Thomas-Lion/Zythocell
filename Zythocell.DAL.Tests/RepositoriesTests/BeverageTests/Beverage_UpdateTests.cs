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
    public class Beverage_UpdateTests
    {
        [TestMethod]
        public void UpdateBeverage_Correct()
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

            var result = BRepo.Insert(beverage);
            BRepo.Save();

            result.Name = "Peak Triple";
            result.Alcohol = 8.5;

            BRepo.Update(result);
            BRepo.Save();
            Assert.AreEqual(8.5, BRepo.GetById(result.Id).Alcohol);
            Assert.AreEqual("Peak Triple", BRepo.GetById(result.Id).Name);
        }
    }
}
