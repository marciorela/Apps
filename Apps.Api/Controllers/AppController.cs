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
    [Route("[controller]")]
    //    [Route("api/v1/[controller]")]
    public class AppController : ControllerBase
    {
        private readonly AppsRepository repoApp;

        public AppController(AppsRepository repoApp)
        {
            this.repoApp = repoApp;
        }

        [HttpGet("{buscar}")]
        public async Task<IEnumerable<App>> Get(string buscar)
        {
            return await repoApp.FindByTextAsync(buscar);
        }

        [HttpGet()]
        public async Task<IEnumerable<App>> Get()
        {
            return await repoApp.FindByTextAsync("");
        }
    }
}
