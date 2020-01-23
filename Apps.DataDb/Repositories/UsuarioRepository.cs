using Apps.DataDb.Context;
using Apps.DataDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataDb.Repositories
{
    public class UsuarioRepository : Repository
    {
        public UsuarioRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await ctx.Usuarios.FirstOrDefaultAsync(x => x.Mail == email);
        }

    }
}
