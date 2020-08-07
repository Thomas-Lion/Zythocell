using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.Interfaces.IUsesCases
{
    public interface ICellarUsesCases
    {
        BeverageTO CreateANewBeverage(BeverageTO beverage);
        //ADMIN bool DeleteBeverage(BeverageTO beverage);
        BeverageTO UpdateABeverage(BeverageTO beverage);
        BeverageTO GetABeverage(string name);
        BeverageTO GetABeverage(int id);


        CellarTO AdditionToCellar(CellarTO cellar);
        CellarTO UpdateAnEntry(CellarTO cellar);
        List<CellarTO> GetAllCellar(Guid user);
        //Calendar GetHistory(Guid user)
        List<CellarTO> SearchEntry(string search);
        CellarTO MinusOne(CellarTO cellar);
        CellarTO PlusOne(CellarTO cellar);

        RateTO CreateANewRating(RateTO rate);
        RateTO UpdateARating(RateTO rate);
        bool DeleteARating(Guid user,RateTO rating);
        List<RateTO> GetAllRating(Guid user);
    }
}
