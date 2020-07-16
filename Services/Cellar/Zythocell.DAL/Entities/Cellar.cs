using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.DAL.Entities
{
    public class Cellar
    {
        public Guid UserId { get; set; }
        public int BeverageId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public DateTime Age { get; set; }
    }
}
