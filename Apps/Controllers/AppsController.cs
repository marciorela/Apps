using Apps.DataDb.Models;
using Apps.DataDb.Repositories;
using Apps.DataDb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly CategoriaRepository repoCategoria;

        public AppsController(AppsRepository appsRepo, CategoriaRepository repoCategoria)
        {
            this.appsRepo = appsRepo;
            this.repoCategoria = repoCategoria;
        }

        public async Task GetCategoriasInViewBag()
        {
            var categorias = await repoCategoria.GetAllAsync();
            ViewBag.Categorias = categorias.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Nome });
        }

        public async Task<IActionResult> Index(string buscar)
        {
            var apps = await appsRepo.FindByTextAsync(buscar ?? "");

            return View(apps);
        }

        [HttpGet]
        public async Task<IActionResult> Novo()
        {
            await GetCategoriasInViewBag();
            return View();
        }

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
