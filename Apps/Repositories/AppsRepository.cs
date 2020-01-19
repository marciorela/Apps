using Apps.Context;
using Apps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Repositories
{
    public class AppsRepository : Repository
    {
        public AppsRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<App>> GetAllAsync()
        {
            return await ctx.Apps.ToListAsync();
        }
    }
}
