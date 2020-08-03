using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.BLL.UsesCases;
using Zythocell.Common.Interfaces;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests.CellarUCTests
{
    [TestClass]
    public class GetAllCellarUCTests
    {
        public List<CellarTO> MockCellars()
        {
            var cellar1 = new CellarTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Quantity = 18,
                Date = DateTime.Now,
                AgeBeverage = DateTime.Now.AddDays(-18)
            };
            var cellar2 = new CellarTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 2,
                Quantity = 60,
                Date = DateTime.Now,
                AgeBeverage = DateTime.Now.AddDays(-60)
            };
            var cellar3 = new CellarTO
            {
                Id = 1,
                //UserId = new Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"),
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 3,
                Quantity = 120,
                Date = DateTime.Now,
                AgeBeverage = DateTime.Now.AddDays(-120)
            };
            return new List<CellarTO> { cellar1, cellar2, cellar3 };
        }

        [TestMethod]
        public void GetAllCellar_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.GetByUser(It.IsAny<Guid>()))
                   .Returns(MockCellars());
            var sut = new CellarUsesCases(mockUOW.Object);

            var allCellar = sut.GetAllCellar(userA);

            Assert.IsNotNull(allCellar);
            Assert.AreEqual(allCellar.Count, 3);
        }

        [TestMethod]
        public void GetAllCellarEmptyGuid_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.GetByUser(It.IsAny<Guid>()))
                   .Returns(MockCellars());
            var sut = new CellarUsesCases(mockUOW.Object);

            var allCellar = sut.GetAllCellar(userA);

            Assert.ThrowsException<ArgumentNullException>(() => sut.GetAllCellar(new Guid()));
        }
    }
}
