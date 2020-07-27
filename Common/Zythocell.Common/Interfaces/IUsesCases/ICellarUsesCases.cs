using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.Interfaces.IUsesCases
{
    public interface ICellarUsesCases
    {
        BeverageTO CreateANewBeverage(BeverageTO beverage);
        //admin DeleteBeverage
        BeverageTO UpdateABeverage(BeverageTO beverage);
        BeverageTO GetABeverage(string name);


        CellarTO AdditionToCellar(CellarTO cellar);
        CellarTO UpdateAnEntry(CellarTO cellar);
        List<CellarTO> GetAllCellar(Guid user);
        //Calendar GetHistory(Guid user)
        List<CellarTO> SearchEntry(string search);


        RateTO CreateANewRating(RateTO rate);
        RateTO UpdateARating(RateTO rate);
        //bool DeleteARating(Guid user,RateTO rating);
        List<RateTO> GetAllRating(Guid user);
    }
}
