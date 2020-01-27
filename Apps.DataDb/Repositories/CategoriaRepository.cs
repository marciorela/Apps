using Apps.DataDb.Context;
using Apps.DataDb.Models;
using Apps.DataDb.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Repositories
{
    public class CategoriaRepository : Repository
    {
        public CategoriaRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await ctx.Categorias.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Categoria> FindByNomeAsync(string nome)
        {
            return await ctx.Categorias.FirstOrDefaultAsync(c => c.Nome.Trim().ToLower() == nome.Trim().ToLower());
        }
    }
}
