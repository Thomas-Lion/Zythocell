using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zythocell.BLL.UsesCases;
using Zythocell.Common.Enum;
using Zythocell.Common.Interfaces;
using Zythocell.Common.Interfaces.IUsesCases;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests.RateUCTests
{
    [TestClass]
    public class GetAllRateUCTests
    {
        #region INIT
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
        public List<RateTO> MockRatesUserA()
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

            return new List<RateTO> { rate1, rate2, rate3, rate4 };
        }
        #endregion

        [Ignore]
        //ignore if GetByUserId still in repo 
        [TestMethod]
        public void GetAllRatingByUserId_Succesfull()
        {
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.GetAll())
                   .Returns(MockRates());

            var sut = new CellarUsesCases(mockUOW.Object);
            var result = sut.GetAllRating(userA);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GetAllRatingByUserA_Succesfull()
        {
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.GetByUser(userA))
                   .Returns(MockRatesUserA());

            var sut = new CellarUsesCases(mockUOW.Object);
            var result = sut.GetAllRating(userA);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }
    }
}
