using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Extensions
{
    public static class CellarExtensions
    {
        public static CellarTO ToTO(this CellarEF cellar)
        {
            if (cellar is null)
            {
                throw new ArgumentNullException(nameof(cellar));
            }

            return new CellarTO
            {
                Id = cellar.Id,
                BeverageId = cellar.BeverageId,
                UserId = cellar.UserId,
                Quantity = cellar.Quantity,
                AgeBeverage = cellar.AgeBeverage,
                Date = cellar.Date,
                SmallDescription = cellar.SmallDescription
            };
        }

        public static CellarEF ToEF(this CellarTO cellar)
        {
            if (cellar is null)
            {
                throw new ArgumentNullException(nameof(cellar));
            }

            return new CellarEF
            {
                Id = cellar.Id,
                BeverageId = cellar.BeverageId,
                UserId = cellar.UserId,
                Quantity = cellar.Quantity,
                AgeBeverage = cellar.AgeBeverage,
                Date = cellar.Date,
                SmallDescription = cellar.SmallDescription,
            };
        }

        public static CellarEF UpdateFromDetached(this CellarEF cAttach, CellarEF cDetached)
        {
            if (cAttach is null)
                throw new ArgumentNullException();

            if (cDetached is null)
                throw new NullReferenceException();

            if (cAttach.Id != cDetached.Id)
                throw new Exception("Cannot update Cellar because it is not the same ID.");

            if ((cAttach != default) && (cDetached != default))
            {
                cAttach.Id = cDetached.Id;
                cAttach.BeverageId = cDetached.BeverageId;
                cAttach.Quantity = cDetached.Quantity;
                cAttach.AgeBeverage = cDetached.AgeBeverage;
                cAttach.Date = cDetached.Date;
                cAttach.SmallDescription = cDetached.SmallDescription;
            }

            return cAttach;
        }
    }
}
