using models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.ViewModel
{
    public class UsuarioDAL
    {
        public List<UsuarioViewModel> ListUsers() {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                var users = (from u in db.Usuarios
                             join tid in db.TipoIdentificacions
                             on u.IdTipoIdentificacion equals tid.IdTipoIdentificacion
                             select new UsuarioViewModel
                             {
                                 idUsuario = u.idUsuario,
                                 Nombres = u.Nombres,
                                 Apellidos = u.Apellidos,
                                 NumeroIdentificacion = u.NumeroIdentificacion,
                                 CorreoElectronico = u.CorreoElectronico,
                                 FechaNacimiento = u.FechaNacimiento,
                                 Direccion = u.Direccion,
                                 Telefono = u.Telefono,
                                 PaisOrigen = u.PaisOrigen,
                                 TipoIdentificacion = tid.NombreTipoIdentificacion.ToString()
                             }).ToList();

                return users;
            }
        }

        public bool CreateUser(models.Usuario usuario)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {   
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public UsuarioViewModel FindUserById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    var user = (from u in db.Usuarios
                                 join tid in db.TipoIdentificacions
                                 on u.IdTipoIdentificacion equals tid.IdTipoIdentificacion
                                 where u.idUsuario == id
                                 select new UsuarioViewModel
                                 {
                                     idUsuario = u.idUsuario,
                                     Nombres = u.Nombres,
                                     Apellidos = u.Apellidos,
                                     NumeroIdentificacion = u.NumeroIdentificacion,
                                     CorreoElectronico = u.CorreoElectronico,
                                     FechaNacimiento = u.FechaNacimiento,
                                     Direccion = u.Direccion,
                                     Telefono = u.Telefono,
                                     PaisOrigen = u.PaisOrigen,
                                     IdTipoIdentificacion = tid.IdTipoIdentificacion,
                                     TipoIdentificacion = tid.NombreTipoIdentificacion.ToString()
                                 }).FirstOrDefault();
                    db.SaveChanges();
                    return user;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditUser(models.Usuario usuario) {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                   models.Usuario usuario =  db.Usuarios.Find(id);
                   db.Usuarios.Remove(usuario);
                   db.SaveChanges();   
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
