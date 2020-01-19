using Apps.Models;
using Apps.Repositories;
using Apps.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepo;

        public UsuarioController(UsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public IActionResult NovoUsuario() => View();

        [HttpPost]
        public async Task<IActionResult> NovoUsuario(UsuarioCadVM usuarioVM)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioVM);
            }

            usuarioVM.Email = usuarioVM.Email.Trim().ToLower();

            Usuario usuario = await _usuarioRepo.GetUsuarioByEmailAsync(usuarioVM.Email);
            if (usuario != null)
            {
                ModelState.AddModelError("","E-mail já cadastrado.");
                return View(usuarioVM);
            }

            usuario = new Usuario();
            usuario = usuarioVM.ToModel(usuario);

            _usuarioRepo.Add(usuario);
            await _usuarioRepo.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
