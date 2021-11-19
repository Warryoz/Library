using System.Collections.Generic;
using DAL.ViewModel;
using models;
using models.ViewModels;

public class UsuarioBLL
    {
        private UsuarioDAL UsuarioDAL = new UsuarioDAL();
        public List<UsuarioViewModel> ListUsers()
        {
            return UsuarioDAL.ListUsers();
        }

    public bool CreateUser(Usuario usuario) 
    {
        if (UsuarioDAL.CreateUser(usuario))
        {
            return true;
        }
        return false;

    }

    public bool EditUser(Usuario usuario)
    {
        if (UsuarioDAL.EditUser(usuario))
        {
            return true;
        }
        return false;

    }

    public UsuarioViewModel FindUserById(int id)
    {
        return UsuarioDAL.FindUserById(id);
    }

    public bool DeleteUser(int id)
    {

        if (UsuarioDAL.DeleteUser(id))
        {
            return true;
        }
        return false;

    }
}
