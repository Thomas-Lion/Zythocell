using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Enum;

namespace Zythocell.DAL.Entities
{
    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BeverageType BeveragType { get; set; }
        public string Country { get; set; }
        public string Productor { get; set; }
        public int Alcohol { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }
        //picture ?
    }
}
