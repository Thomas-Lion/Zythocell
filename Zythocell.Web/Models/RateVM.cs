using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zythocell.Web.Models
{
    public class RateVM
    {
        [HiddenInput]
        public int CellarId { get; set; }
        [HiddenInput]
        public int BeverageId { get; set; }
        [Display(Name = "Beer")]
        public string NameBeverage { get; set; }
        [HiddenInput]
        public int RateId { get; set; }

        [Display(Name = "Rate")]
        [Range(0.00, 10.00, ErrorMessage = "Rate must be between 0 and 10")]
        public double Rating { get; set; }
        [Display(Name = "Comment")]
        [StringLength(1024)]
        public string Comment { get; set; }
        [Display(Name = "Description")]
        [StringLength(256)]
        public string SmallDescription { get; set; }
        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "You can't have more than 2147483647. Sorry")]
        public int QuantityBeverage { get; set; }

        [Display(Name = "Cellar added the")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Bottled/Bought in")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime AgeBeverage { get; set; }
    }
}
