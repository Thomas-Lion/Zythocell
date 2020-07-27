using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Interfaces.IUsesCases;
using Zythocell.Common.TransferObject;

namespace Zythocell.BLL.UsesCases
{
    public class CellarUsesCases : ICellarUsesCases
    {
        public CellarTO AdditionToCellar(CellarTO cellar)
        {
            throw new NotImplementedException();
        }

        public BeverageTO CreateANewBeverage(BeverageTO beverage)
        {
            throw new NotImplementedException();
        }

        public RateTO CreateANewRating(Guid user, int beverageId)
        {
            throw new NotImplementedException();
        }

        public BeverageTO GetABeverage(string name)
        {
            throw new NotImplementedException();
        }

        public List<CellarTO> GetAllCellar(Guid user)
        {
            throw new NotImplementedException();
        }

        public List<RateTO> GetAllRating(Guid user)
        {
            throw new NotImplementedException();
        }

        public List<CellarTO> SearchEntry(string search)
        {
            throw new NotImplementedException();
        }

        public BeverageTO UpdateABeverage(BeverageTO beverage)
        {
            throw new NotImplementedException();
        }

        public CellarTO UpdateAnEntry(CellarTO cellar)
        {
            throw new NotImplementedException();
        }

        public RateTO UpdateARating(RateTO rating)
        {
            throw new NotImplementedException();
        }
    }
}
