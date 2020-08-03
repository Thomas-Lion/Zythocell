using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Extensions
{
    public static class RateExtensions
    {
        public static RateTO ToTO(this RateEF rate)
        {
            if (rate is null)
            {
                throw new ArgumentNullException(nameof(rate));
            }

            return new RateTO
            {
                Id = rate.Id,
                BeverageId = rate.BeverageId,
                UserId = rate.UserId,
                Comment = rate.Comment,
                Rating = rate.Rating,
                IsDeleted = rate.IsDeleted
            };
        }

        public static RateEF ToEF(this RateTO rate)
        {
            if (rate is null)
            {
                throw new ArgumentNullException(nameof(rate));
            }

            return new RateEF
            {
                Id = rate.Id,
                BeverageId = rate.BeverageId,
                UserId = rate.UserId,
                Comment = rate.Comment,
                Rating = rate.Rating,
                IsDeleted = rate.IsDeleted
            };
        }

        public static RateEF UpdateFromDetached(this RateEF rAttach, RateEF rDetached)
        {
            if (rAttach is null)
                throw new ArgumentNullException();

            if (rDetached is null)
                throw new NullReferenceException();

            if (rAttach.Id != rDetached.Id)
                throw new Exception("Cannot update Rating because it is not the same ID.");

            if ((rAttach != default) && (rDetached != default))
            {
                rAttach.Id = rDetached.Id;
                rAttach.BeverageId = rDetached.BeverageId;
                rAttach.UserId = rDetached.UserId;
                rAttach.Rating = rDetached.Rating;
                rAttach.Comment = rDetached.Comment;
                rAttach.IsDeleted = rDetached.IsDeleted;
            }

            return rAttach;
        }
    }
}
