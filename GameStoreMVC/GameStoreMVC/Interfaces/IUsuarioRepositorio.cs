using GameStoreMVC.Models;

namespace GameStoreMVC.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario? BuscarPorEmail(string email);
        void Cadastrar(Usuario usuario);
        bool EmailJaCadastrado(string email);
    }
}