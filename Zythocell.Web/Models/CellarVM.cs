using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zythocell.Web.Models
{
    public class CellarVM
    {
        [HiddenInput]
        public int BeverageId { get; set; }
        [HiddenInput]
        public int CellarId { get; set; }
        public string NameBeverage { get; set; }
        public int QuantityBeverage { get; set; }
        public double Alcohol { get; set; }
        public int SizeBottle { get; set; }
        //120char +-
        public string SmallDescription { get; set; }

        [Display(Name = "Bottled/Bought in")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime DateBotteling { get; set; }
    }
}
