using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zythocell.Web.Models
{
    public class RateVM
    {
        public int CellarId { get; set; }
        public int BeverageId { get; set; }
        public int RateId { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public string SmallDescription { get; set; }
        public int QuantityBeverage { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AgeBeverage { get; set; }
    }
}
