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
    public class UpdateRateUCTests
    {
        [TestMethod]
        public void UpdateARating_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Update(It.IsAny<RateTO>()))
                   .Returns(new RateTO { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            var updated = sut.UpdateARating(rate);

            Assert.IsNotNull(updated);
            Assert.AreEqual("Rate1 UAAA B1", updated.Comment);
        }

        [TestMethod]
        public void UpdateARatingNull_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Update(It.IsAny<RateTO>()))
                   .Returns(new RateTO { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);

            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateARating(null));
        }

        [TestMethod]
        public void UpdateARatingNegativeBeverageId_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Update(It.IsAny<RateTO>()))
                   .Returns(new RateTO { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var negatBId = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = -1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateARating(negatBId));
        }

        [TestMethod]
        public void UpdateARatingNegativeRating_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.RateRepository.Update(It.IsAny<RateTO>()))
                   .Returns(new RateTO { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var negatRating = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = -1
            };

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateARating(negatRating));
        }
    }
}
