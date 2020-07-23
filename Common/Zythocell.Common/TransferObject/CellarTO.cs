using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Common.TransferObject
{
    public class CellarTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BeverageId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public DateTime Age { get; set; }
    }
}
