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
    public class UpdateABeverageUCTests
    {
        [TestMethod]
        public void UpdateABeverage_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Update(It.IsAny<BeverageTO>()))
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

            var updated = sut.UpdateABeverage(beverage);

            Assert.IsNotNull(updated);
            mockUOW.Verify(u => u.BeverageRepository.Update(It.IsAny<BeverageTO>()), Times.Once);
        }

        [TestMethod]
        public void UpdateABeverageNegativeAlcohol_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Update(It.IsAny<BeverageTO>()))
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

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateABeverage(beverage));
        }

        [TestMethod]
        public void UpdateABeverageNegativeSize_ThrowArgumentException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Update(It.IsAny<BeverageTO>()))
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

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateABeverage(beverage));
        }

        [TestMethod]
        public void UpdateABeverageNull_ThrowArgumentNullException()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.BeverageRepository.Update(It.IsAny<BeverageTO>()))
                   .Returns(new BeverageTO { Id = 1, Name = "Peak Triple", BeverageType = BeverageType.Beer, Country = "Belgium", Productor = "Belgium Peak Beer SR", Alcohol = 8.5, Size = 33, Color = "Brown", IsDeleted = false });

            var sut = new CellarUsesCases(mockUOW.Object);
            
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateABeverage(null));
        }
    }
}
