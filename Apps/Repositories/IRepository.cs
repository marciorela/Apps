using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Repositories
{
    public interface IRepository
    {
        public Task SaveChangesAsync();
        public void Add(Entity entity);
    }
}
