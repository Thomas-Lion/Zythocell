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
                Rating = rate.Rating
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
                Rating = rate.Rating
            };
        }

        public static RateEF UpdateFromDetached(this RateEF qAttach, RateEF qDetached)
        {
            if (qAttach is null)
                throw new ArgumentNullException();

            if (qDetached is null)
                throw new NullReferenceException();

            if (qAttach.Id != qDetached.Id)
                throw new Exception("Cannot update Rating because it is not the same ID.");

            if ((qAttach != default) && (qDetached != default))
            {
                qAttach.Id = qDetached.Id;
                qAttach.BeverageId = qDetached.BeverageId;
                qAttach.UserId = qDetached.UserId;
                qAttach.Rating = qDetached.Rating;
                qAttach.Comment = qDetached.Comment;
            }

            return qAttach;
        }
    }
}
