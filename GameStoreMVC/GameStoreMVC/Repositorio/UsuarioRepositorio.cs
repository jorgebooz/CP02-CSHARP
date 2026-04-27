using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;

namespace GameStoreMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static readonly List<Usuario> _usuarios = new();
        private static int _proximoId = 1;

        public Usuario? BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Id = _proximoId++;
            _usuarios.Add(usuario);
        }

        public bool EmailJaCadastrado(string email)
        {
            return _usuarios.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}


//teste 