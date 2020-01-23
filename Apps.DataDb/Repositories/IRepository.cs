using Apps.DataDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Repositories
{
    public interface IRepository
    {
        public Task SaveChangesAsync();
        public void Add(Entity entity);
    }
}
