using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Enum;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.Tests.UsesCasesTests.BeverageUCTests
{
    class GetABeverageUCTests
    {
        public List<BeverageTO> MockBeverages()
        {
            var beverage1 = new BeverageTO
            {
                Id = 1,
                Name = "Peak Triple",
                BeveragType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Belgium Peak Beer SR",
                Alcohol = 8.5,
                Size = 33,
                Color = "Brown",
                IsDeleted = false
            };
            var beverage2 = new BeverageTO
            {
                Id = 2,
                Name = "Orval",
                BeveragType = BeverageType.Beer,
                Color = "Brown",
                Country = "Belgium",
                Productor = "Abbaye d'Orval",
                Size = 33,
                Alcohol = 6.2,
                IsDeleted = false
            };
            var beverage3 = new BeverageTO
            {
                Id = 3,
                Name = "Valduc Fée Steve",
                BeveragType = BeverageType.Beer,
                Country = "Belgium",
                Productor = "Brasserie Coopérative Valduc-Thor",
                Alcohol = 6.3,
                Size = 33,
                Color = "Blond",
                IsDeleted = false
            };
            return new List<BeverageTO> { beverage1, beverage2, beverage3 };
        }

    }
}
