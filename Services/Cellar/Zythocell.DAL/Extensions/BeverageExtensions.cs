using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Extensions
{
    public static class BeverageExtensions
    {
        public static BeverageTO ToTO(this BeverageEF beverage)
        {
            if (beverage is null)
            {
                throw new ArgumentNullException(nameof(beverage));
            }

            return new BeverageTO
            {
                Id = beverage.Id,
                BeveragType = beverage.BeveragType,
                Name = beverage.Name,
                Country = beverage.Country,
                Productor = beverage.Productor,
                Size = beverage.Size,
                Alcohol = beverage.Alcohol,
                Color = beverage.Color,
                IsDeleted = beverage.IsDeleted
            };
        }
        
        public static BeverageEF ToEF(this BeverageTO beverage)
        {
            if (beverage is null)
            {
                throw new ArgumentNullException(nameof(beverage));
            }

            return new BeverageEF
            {
                Id = beverage.Id,
                BeveragType = beverage.BeveragType,
                Name = beverage.Name,
                Country = beverage.Country,
                Productor = beverage.Productor,
                Size = beverage.Size,
                Alcohol = beverage.Alcohol,
                Color = beverage.Color,
                IsDeleted = beverage.IsDeleted
            };
        }

        public static BeverageEF UpdateFromDetached(this BeverageEF qAttach, BeverageEF qDetached)
        {
            if (qAttach is null)
                throw new ArgumentNullException();

            if (qDetached is null)
                throw new NullReferenceException();

            if (qAttach.Id != qDetached.Id)
                throw new Exception("Cannot update Beverage because it is not the same ID.");

            if ((qAttach != default) && (qDetached != default))
            {
                qAttach.Id = qDetached.Id;
                qAttach.BeveragType = qDetached.BeveragType;
                qAttach.Name = qDetached.Name;
                qAttach.Country = qDetached.Country;
                qAttach.Productor = qDetached.Productor;
                qAttach.Size = qDetached.Size;
                qAttach.Alcohol = qDetached.Alcohol;
                qAttach.Color = qDetached.Color;
                qAttach.IsDeleted = qDetached.IsDeleted;
                
            }

            return qAttach;
        }
    }
}
