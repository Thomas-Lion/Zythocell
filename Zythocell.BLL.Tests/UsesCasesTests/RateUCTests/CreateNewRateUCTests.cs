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
    public class CreateNewRateUCTests
    {
        [TestMethod]
        public void CreateNewRate_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            var inserted = sut.CreateANewRating(rate);

            mockUOW.Verify(u => u.RateRepository.Insert(It.IsAny<RateTO>()), Times.Once);
            Assert.IsNotNull(inserted);
        }

        [TestMethod]
        public void CreateNewRateNull_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);

            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateANewRating(null));
        }

        [TestMethod]
        public void CreateNewRateAlreadyHaveAnId_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                Id = 1,
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentException>(() => sut.CreateANewRating(rate));
        }

        [TestMethod]
        public void CreateNewRateEmptyGuid_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                UserId = new Guid(),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateANewRating(rate));
        }

        [TestMethod]
        public void CreateNewRateNegativeBeverageId_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = -1,
                Comment = "Rate1 UAAA B1",
                Rating = 1
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateANewRating(rate));
        }

        [TestMethod]
        public void CreateNewRateNegativeRating_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(r=>r.RateRepository.Insert(It.IsAny<RateTO>()))
                   .Returns(new RateTO  { Id = 1, UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), BeverageId = 1, Comment = "Rate1 UAAA B1", Rating = 1 });

            var sut = new CellarUsesCases(mockUOW.Object);
            var rate = new RateTO
            {
                UserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
                BeverageId = 1,
                Comment = "Rate1 UAAA B1",
                Rating = -1
            };

            Assert.ThrowsException<ArgumentException>(() => sut.CreateANewRating(rate));
        }
    }
}
