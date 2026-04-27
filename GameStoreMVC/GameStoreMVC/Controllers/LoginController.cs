using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.BuscarPorEmail(email);

            if (usuario == null || usuario.Senha != senha)
            {
                ViewBag.Erro = "E-mail ou senha inválidos.";
                return View();
            }

            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
            HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CriarConta() => View();

        [HttpPost]
        public IActionResult CriarConta(Usuario usuario)
        {
            if (!ModelState.IsValid) return View(usuario);

            if (_usuarioRepositorio.EmailJaCadastrado(usuario.Email))
            {
                ModelState.AddModelError("Email", "Este e-mail já está cadastrado.");
                return View(usuario);
            }

            _usuarioRepositorio.Cadastrar(usuario);
            TempData["Sucesso"] = "Conta criada com sucesso! Faça login.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}