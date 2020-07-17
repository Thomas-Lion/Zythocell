using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public interface IBeverageRepository : IRepository<Beverage>
    {
        public ICollection<Beverage> GetAll();
        public bool Delete(Beverage entity);        
    }
}
