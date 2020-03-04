using Apps.DataDb.Models;
using Apps.DataDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apps.Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("v1")]
    public class AppController : ControllerBase
    {
        private readonly AppsRepository repoApp;

        public AppController(AppsRepository repoApp)
        {
            this.repoApp = repoApp;
        }

        [HttpGet("search/{buscar}")]
        public async Task<IEnumerable<App>> Get(string buscar)
        {
            return await repoApp.FindByTextAsync(buscar);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<App>> Get()
        {
            return await repoApp.FindByTextAsync("");
        }

        [HttpGet("outro")]
        public Outro uuu()
        {
            return new Outro { Id = "345", Nome = "Rela" };
        }

        [HttpPost("pst")]
        public string pst(Outro outro)
        {
            if (outro == null)
            {
                return "NULO";
            } 
            else
            {
                return "RETORNADO: " + outro.Nome;
            }
        }
    }

    public class Outro
    {
        public string Id { get; set; }
        public string Nome { get; set; }

    }
}
