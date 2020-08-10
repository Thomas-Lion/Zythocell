using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.DAL.Entities
{
    public class RateEF
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BeverageId { get; set; }
        public int CellarId { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
    }
}
