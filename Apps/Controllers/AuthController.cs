using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult SignIn() => View();
    }
}
