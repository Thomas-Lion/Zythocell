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
    public class MinusOneUCTests
    {
        [TestMethod]
        public void MinusOne_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 0, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            var updated = sut.MinusOne(cellar);

            Assert.IsNotNull(updated);
            mockUOW.Verify(u => u.CellarRepository.Update(It.IsAny<CellarTO>()), Times.Once);
        }

        [TestMethod]
        public void MinusOneZeroQuantity_ReturnSameObject()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 0, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = 0,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            var updated = sut.MinusOne(cellar);

            Assert.IsNotNull(updated);
            mockUOW.Verify(u => u.CellarRepository.Update(It.IsAny<CellarTO>()), Times.Once);
        }

        [TestMethod]
        public void MinusOneNegativeQuantity_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 0, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = -1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateAnEntry(cellar));
        }
    }
}
