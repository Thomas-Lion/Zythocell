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
    public class AdditionToCellarUCTests
    {
        [TestMethod]
        public void AdditionToCellar_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            var added = sut.AdditionToCellar(cellar);

            Assert.IsNotNull(added);
            mockUOW.Verify(u => u.CellarRepository.Insert(It.IsAny<CellarTO>()), Times.Once);
        }

        [TestMethod]
        public void AdditionToCellarNull_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);

            Assert.ThrowsException<ArgumentNullException>(() => sut.AdditionToCellar(null));
        }

        [TestMethod]
        public void AdditionToCellarEmptyGuid_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = new Guid(),
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.AdditionToCellar(cellar));
        }

        [TestMethod]
        public void AdditionToCellarNegativeBeverageId_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = -5,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.AdditionToCellar(cellar));
        }

        [TestMethod]
        public void AdditionToCellarNegativeQuantity_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = -50,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentException>(() => sut.AdditionToCellar(cellar));
        }

        [TestMethod]
        public void AdditionToCellarAlredyAnId_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Insert(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO(){ Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                Id = 1,
                BeverageId = 1,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentException>(() => sut.AdditionToCellar(cellar));
        }
    }
}
