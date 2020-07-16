using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public interface IBeverageRepository : IRepository<Beverage>
    {
        public bool Delete(Beverage entity);
        public Beverage GetById(int Id);
    }
}
