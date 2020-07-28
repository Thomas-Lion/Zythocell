using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.BLL.UsesCases;
using Zythocell.Common.Enum;
using Zythocell.Common.Interfaces;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests
{
    [TestClass]
    public class RateUCTests
    {
        public List<BeverageTO> MockBeverages()
        {
            var beverage1 = new BeverageTO
            {
                Id = 1,
                Name = "Peak Triple",
                BeveragType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = 8.5,
                Size = 33,
                Color = "Brown",
                IsDeleted = false
            };
            var beverage2 = new BeverageTO
            {
                Id = 2,
                Name = "Orval",
                BeveragType = BeverageType.Beer,
                Color = "Brown",
                Country = "Belgium",
                Productor = "Abbaye d'Orval",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };
            var beverage3 = new BeverageTO
            {
                Id = 3,
                Name = "Valduc Fée Steve",
                BeveragType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Brasserie Coopérative Valduc-Thor",
                Alcohol = 6.3,
                Size = 33,
                Color = "Blond",
                IsDeleted = false
            };
            return new List<BeverageTO> { beverage1, beverage2, beverage3 };
        }
        public List<CellarTO> MockCellars()
        {
            var cellar1 = new CellarTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Quantity = 18,
                Date = DateTime.Now,
                Age = DateTime.Now.AddDays(-18)
            };
            var cellar2 = new CellarTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 2,
                Quantity = 60,
                Date = DateTime.Now,
                Age = DateTime.Now.AddDays(-60)
            };
            var cellar3 = new CellarTO
            {
                Id = 1,
                UserId = new Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"),
                BeverageId = 3,
                Quantity = 120,
                Date = DateTime.Now,
                Age = DateTime.Now.AddDays(-120)
            };
            return new List<CellarTO> { cellar1, cellar2, cellar3 };
        }
        public List<RateTO> MockRates()
        {
            var rate1 = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };
            var rate2 = new RateTO
            {
                Id = 2,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate2 UAAA B1",
                Rating = 2
            };
            var rate3 = new RateTO
            {
                Id = 3,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 2,
                Comment = "Rate3 UAAA B2",
                Rating = 3
            };
            var rate4 = new RateTO
            {
                Id = 4,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 3,
                Comment = "Rate4 UAAA B3",
                Rating = 4
            };
            var rate5 = new RateTO
            {
                Id = 5,
                UserId = new Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"),
                BeverageId = 1,
                Comment = "Rate5 UBBB B1",
                Rating = 5
            };
            var rate6 = new RateTO
            {
                Id = 6,
                UserId = new Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"),
                BeverageId = 3,
                Comment = "Rate6 UBBB B3",
                Rating = 6
            };
            return new List<RateTO> { rate1, rate2, rate3, rate4, rate5, rate6 };
        }
        [TestMethod]
        public void GetAllRatingByUserId_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");
            //var userB = new Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB");

            mockUOW.Setup(x => x.RateRepository.GetAll()).Returns(MockRates());


            var sut = new CellarUsesCases(mockUOW.Object);
            var result = sut.GetAllRating(userA);

            mockUOW.Verify(x => x.RateRepository.GetAll(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }
    }
}
