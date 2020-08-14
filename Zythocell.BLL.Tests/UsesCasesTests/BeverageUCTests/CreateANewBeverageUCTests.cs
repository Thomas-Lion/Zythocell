using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.BLL.UsesCases;
using Zythocell.Common.Enum;
using Zythocell.Common.Interfaces;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests.BeverageUCTests
{
    [TestClass]
    public class CreateANewBeverageUCTests
    {
        [TestMethod]
        public void CreateANewBeverage_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Insert(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);
            var beverage = new BeverageTO
            {
                Name = "Peak Triple",
                BeverageType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = 8.5,
                Size = 33,
                Color = "Brown",
            }; 

            var added = sut.CreateANewBeverage(beverage);

            Assert.IsNotNull(added);
            Assert.IsFalse(added.IsDeleted);
            mockUOW.Verify(u => u.BeverageRepository.Insert(It.IsAny<BeverageTO>()), Times.Once);
        }

        [TestMethod]
        public void CreateANewBeverageAlreadyAnId_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Insert(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);
            var beverage = new BeverageTO
            {
                Id = 1,
                Name = "Peak Triple",
                BeverageType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = 8.5,
                Size = 33,
                Color = "Brown",
            };

            Assert.ThrowsException<ArgumentException>(() => sut.CreateANewBeverage(beverage));
        }

        [TestMethod]
        public void CreateANewBeverageNegativeSize_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Insert(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);
            var beverage = new BeverageTO
            {
                Name = "Peak Triple",
                BeverageType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = 8.5,
                Size = -33,
                Color = "Brown",
            };

            Assert.ThrowsException<ArgumentException>(() => sut.CreateANewBeverage(beverage));
        }

        [TestMethod]
        public void CreateANewBeverageNegativeAlcohol_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Insert(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);
            var beverage = new BeverageTO
            {
                Name = "Peak Triple",
                BeverageType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = -8.5,
                Size = 33,
                Color = "Brown",
            };

            Assert.ThrowsException<ArgumentException>(() => sut.CreateANewBeverage(beverage));
        }

        [TestMethod]
        public void CreateANewBeverageNull_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Insert(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);

            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateANewBeverage(null));
        }
    }
}
