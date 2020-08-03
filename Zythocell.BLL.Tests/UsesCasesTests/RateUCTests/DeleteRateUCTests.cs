using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.BLL.UsesCases;
using Zythocell.Common.Interfaces;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests.RateUCTests
{
    [TestClass]
    public class DeleteRateUCTests
    {
        [TestMethod]
        public void DeleteARating_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Delete(It.IsAny<RateTO>()))
                   .Returns(true);

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            var deleted = sut.DeleteARating(new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), rate);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteARatingAlreadyDeleted_ThrowArgumentExcetion()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Delete(It.IsAny<RateTO>()))
                   .Returns(true);

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1,
                IsDeleted = true
            };

            Assert.ThrowsException<ArgumentException>(() => sut.DeleteARating(new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), rate));
        }

        [TestMethod]
        public void DeleteARatingEmptyGuid_ThrowNullArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Delete(It.IsAny<RateTO>()))
                   .Returns(true);

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.DeleteARating(new Guid(), rate));
        }

        [TestMethod]
        public void DeleteARatingNull_ThrowNullArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Delete(It.IsAny<RateTO>()))
                   .Returns(true);

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.DeleteARating(new Guid(), null));
        }
    }
}
