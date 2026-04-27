using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;

namespace GameStoreMVC.Repositorio
{
    public class GameRepositorio : IGameRepositorio
    {
        private static readonly List<Game> _games = new()
        {
            new Game { Id = 1, Titulo = "Elden Ring", Genero = "RPG", Plataforma = "PC", Preco = 199.90m, Descricao = "Um mundo aberto épico de FromSoftware.", DataCadastro = DateTime.Now },
            new Game { Id = 2, Titulo = "God of War Ragnarök", Genero = "Ação", Plataforma = "PS5", Preco = 249.90m, Descricao = "A saga de Kratos e Atreus continua.", DataCadastro = DateTime.Now },
            new Game { Id = 3, Titulo = "Forza Horizon 5", Genero = "Corrida", Plataforma = "Xbox", Preco = 179.90m, Descricao = "O melhor jogo de corrida open world.", DataCadastro = DateTime.Now },
        };
        private static int _proximoId = 4;

        public List<Game> ListarTodos() => _games.ToList();

        public Game? BuscarPorId(int id) => _games.FirstOrDefault(g => g.Id == id);

        public void Adicionar(Game game)
        {
            game.Id = _proximoId++;
            game.DataCadastro = DateTime.Now;
            _games.Add(game);
        }

        public void Atualizar(Game game)
        {
            var index = _games.FindIndex(g => g.Id == game.Id);
            if (index >= 0) _games[index] = game;
        }

        public void Deletar(int id)
        {
            var game = BuscarPorId(id);
            if (game != null) _games.Remove(game);
        }
    }
}