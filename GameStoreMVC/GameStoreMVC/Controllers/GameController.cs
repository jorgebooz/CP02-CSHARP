using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepositorio _gameRepositorio;

        public GameController(IGameRepositorio gameRepositorio)
        {
            _gameRepositorio = gameRepositorio;
        }

        public IActionResult Index()
        {
            var games = _gameRepositorio.ListarTodos();
            return View(games);
        }

        [HttpGet]
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(Game game)
        {
            if (!ModelState.IsValid) return View(game);
            _gameRepositorio.Adicionar(game);
            TempData["Sucesso"] = "Jogo cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var game = _gameRepositorio.BuscarPorId(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost]
        public IActionResult Editar(Game game)
        {
            if (!ModelState.IsValid) return View(game);
            _gameRepositorio.Atualizar(game);
            TempData["Sucesso"] = "Jogo atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            _gameRepositorio.Deletar(id);
            TempData["Sucesso"] = "Jogo removido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}