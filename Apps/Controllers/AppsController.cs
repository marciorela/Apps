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
        private readonly AppsRepository repoApps;
        private readonly CategoriaRepository repoCategoria;

        public AppsController(AppsRepository appsRepo, CategoriaRepository repoCategoria)
        {
            this.repoApps = appsRepo;
            this.repoCategoria = repoCategoria;
        }

        public async Task GetCategoriasInViewBagAsync()
        {
            var categorias = await repoCategoria.GetAllAsync();
            ViewBag.Categorias = categorias.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Nome });
        }

        public async Task<IActionResult> Index(string buscar)
        {
            var apps = await repoApps.FindByTextAsync(buscar ?? "");

            return View(apps);
        }

        [HttpGet]
        public async Task<IActionResult> Novo()
        {
            await GetCategoriasInViewBagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Novo(AppCadVM dados)
        {
            return await CheckAndSaveAppCadVM(dados, null);
        }

        public async Task<IActionResult> CheckAndSaveAppCadVM(AppCadVM dados, Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return View(dados);
            }

            var app = new App();
            if (id != null)
            {
                app = await repoApps.GetByIdAsync((Guid)id);
                dados.ToModel(app);
                repoApps.Update(app);
            }
            else
            {
                dados.ToModel(app);
                repoApps.Add(app);
            }

            await repoApps.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dados = await repoApps.GetByIdAsync(id);
            if (dados == null)
            {
                return BadRequest();
            }

            await GetCategoriasInViewBagAsync();

            return View(dados.ToVM());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AppCadVM dados)
        {
            return await CheckAndSaveAppCadVM(dados, id);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var dados = await repoApps.GetByIdAsync(id);
            if (dados == null)
            {
                return BadRequest();
            }

            var dadosVM = dados.ToVM();
            dadosVM.CategoriaNome = dados.Categoria.Nome;
            return View(dadosVM);
        }
    }
}
