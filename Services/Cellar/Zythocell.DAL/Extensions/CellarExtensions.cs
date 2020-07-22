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
                Age = cellar.Age,
                Date = cellar.Date
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
                Age = cellar.Age,
                Date = cellar.Date
            };
        }

        public static CellarEF UpdateFromDetached(this CellarEF qAttach, CellarEF qDetached)
        {
            if (qAttach is null)
                throw new ArgumentNullException();

            if (qDetached is null)
                throw new NullReferenceException();

            if (qAttach.Id != qDetached.Id)
                throw new Exception("Cannot update Cellar because it is not the same ID.");

            if ((qAttach != default) && (qDetached != default))
            {
                qAttach.Id = qDetached.Id;
                qAttach.BeverageId = qDetached.BeverageId;
                qAttach.Quantity = qDetached.Quantity;
                qAttach.Age = qDetached.Age;
                qAttach.Date = qDetached.Date;
            }

            return qAttach;
        }
    }
}
