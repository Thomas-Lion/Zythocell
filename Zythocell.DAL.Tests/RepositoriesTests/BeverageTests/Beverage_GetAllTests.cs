using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.Common.Interfaces.IRepositories;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Context;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL.Tests.RepositoriesTests.BeverageTests
{
    [TestClass]
    public class Beverage_GetAllTests
    {
        [TestMethod]
        public void GetAll_NoExceptions()
        {
            var options = new DbContextOptionsBuilder<ZythocellContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new ZythocellContext(options);
            IBeverageRepository BRepo = new BeverageRepository(context);

            var beverage1 = new BeverageTO
            {
                Name = "Orval1",
                BeveragType = BeverageType.Beer,
                Color = "Brown1",
                Country = "Belgium1",
                Productor = "Abbaye d'Orval1",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };
            var beverage2 = new BeverageTO
            {
                Name = "Orval2",
                BeveragType = BeverageType.Beer,
                Color = "Brown2",
                Country = "Belgium2",
                Productor = "Abbaye d'Orval2",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };
            var beverage3 = new BeverageTO
            {
                Name = "Orval3",
                BeveragType = BeverageType.Beer,
                Color = "Brown3",
                Country = "Belgium3",
                Productor = "Abbaye d'Orval3",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = true
            };

            BRepo.Insert(beverage1);
            BRepo.Insert(beverage2);
            BRepo.Insert(beverage3);
            BRepo.Save();

            var result = BRepo.GetAll();

            Assert.AreEqual(2, result.Count());
        }
    }
}
