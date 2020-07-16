using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.DAL.Entities
{
    public class Rate
    {
        public Guid UserId { get; set; }
        public int BeverageId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
