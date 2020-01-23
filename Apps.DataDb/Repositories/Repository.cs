using Apps.DataDb.Models;
using Apps.DataDb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Repositories
{
    public class Repository : IRepository
    {
        public readonly AppDbContext ctx;

        public Repository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Entity entity)
        {
            if (entity.Id == null)
            {
                entity.Id = new Guid();
            }
            entity.DataCadastro = DateTime.Now;

            ctx.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await ctx.SaveChangesAsync();
        }
    }
}
