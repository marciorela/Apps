using Apps.DataDb.Models;
using Apps.DataDb.Repositories;
using Apps.DataDb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepository repoCategoria;

        public CategoriaController(CategoriaRepository repoCategoria)
        {
            this.repoCategoria = repoCategoria;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repoCategoria.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaCreateVM dados)
        {
            if (!ModelState.IsValid)
            {
                return View(dados);
            }

            var categoria = await repoCategoria.FindByNomeAsync(dados.Nome);
            if (categoria != null)
            {
                ModelState.AddModelError("", "Categoria já cadastrada.");
                return View(dados);
            }

            categoria = new Categoria();
            dados.ToModel(categoria);
            repoCategoria.Add(categoria);
            await repoCategoria.SaveChangesAsync();                

            return RedirectToAction("Index");
        }

    }
}
