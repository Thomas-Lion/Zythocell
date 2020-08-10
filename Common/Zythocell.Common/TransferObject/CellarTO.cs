using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zythocell.Common.TransferObject
{
    public class CellarTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BeverageId { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AgeBeverage { get; set; }
        public string SmallDescription { get; set; }
    }
}
