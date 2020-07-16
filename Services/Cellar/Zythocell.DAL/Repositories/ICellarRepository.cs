using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public interface ICellarRepository : IRepository<Cellar>
    {
        public ICollection<Cellar> GetByUser(Guid userId);
        public ICollection<Cellar> OrderByRate(Guid userId);
    }
}
