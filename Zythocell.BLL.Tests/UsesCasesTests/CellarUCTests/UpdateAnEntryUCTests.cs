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
    public class UpdateAnEntryUCTests
    {
        [TestMethod]
        public void UpdateAnEntry_Succesfull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var cellar = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            var updated = sut.UpdateAnEntry(cellar);

            Assert.IsNotNull(updated);
            mockUOW.Verify(u => u.CellarRepository.Update(It.IsAny<CellarTO>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAnEntryNegativeQuantity_ThrowArgumentExecption()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var negatQuantity = new CellarTO()
            {
                BeverageId = 1,
                UserId = userA,
                Quantity = -1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentException>(() => sut.UpdateAnEntry(negatQuantity));
        }
    

        [TestMethod]
        public void UpdateAnEntryNegativeBeverageId_ThrowArgumentNullExecption()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            var userA = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");

            mockUOW.Setup(x => x.CellarRepository.Update(It.IsAny<CellarTO>()))
                   .Returns(new CellarTO() { Id = 1, BeverageId = 1, UserId = userA, Quantity = 1, AgeBeverage = DateTime.Now, Date = DateTime.Now });

            var sut = new CellarUsesCases(mockUOW.Object);
            var negatBId = new CellarTO()
            {
                BeverageId = -1,
                UserId = userA,
                Quantity = 1,
                AgeBeverage = DateTime.Now,
                Date = DateTime.Now
            };

            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateAnEntry(negatBId));
        }
    }
}
