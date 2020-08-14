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
                BeverageType = beverage.BeverageType,
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
                BeverageType = beverage.BeverageType,
                Name = beverage.Name,
                Country = beverage.Country,
                Productor = beverage.Productor,
                Size = beverage.Size,
                Alcohol = beverage.Alcohol,
                Color = beverage.Color,
                IsDeleted = beverage.IsDeleted
            };
        }

        public static BeverageEF UpdateFromDetached(this BeverageEF bAttach, BeverageEF bDetached)
        {
            if (bAttach is null)
                throw new ArgumentNullException();

            if (bDetached is null)
                throw new NullReferenceException();

            if (bAttach.Id != bDetached.Id)
                throw new Exception("Cannot update Beverage because it is not the same ID.");

            if ((bAttach != default) && (bDetached != default))
            {
                bAttach.Id = bDetached.Id;
                bAttach.BeverageType = bDetached.BeverageType;
                bAttach.Name = bDetached.Name;
                bAttach.Country = bDetached.Country;
                bAttach.Productor = bDetached.Productor;
                bAttach.Size = bDetached.Size;
                bAttach.Alcohol = bDetached.Alcohol;
                bAttach.Color = bDetached.Color;
                bAttach.IsDeleted = bDetached.IsDeleted;
                
            }

            return bAttach;
        }
    }
}
