using Apps.Models;
using Apps.Repositories;
using Apps.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Controllers
{
    public class AppsController : Controller
    {
        private readonly AppsRepository appsRepo;

        public AppsController(AppsRepository appsRepo)
        {
            this.appsRepo = appsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var apps = await appsRepo.GetAllAsync();

            return View(apps);
        }

        [HttpGet]
        public IActionResult Novo() => View();

        [HttpPost]
        public async Task<IActionResult> Novo(AppCadVM dados)
        {
            if (!ModelState.IsValid)
            {
                return View(dados);
            }

            var app = new App();
            dados.ToModel(app);

            appsRepo.Add(app);
            await appsRepo.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
