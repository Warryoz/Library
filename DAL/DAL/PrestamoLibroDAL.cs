using models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using models;
namespace DAL.ViewModel
{
    public class PrestamoLibroDAL
    {
        public List<PrestamoLibroViewModel> ListRentedBooks()
        {
            using (BibliotecaEntities db = new BibliotecaEntities())
            {
                var RentedBooks = (from rb in db.PrestamoLibroes
                                   join u in db.Usuarios on rb.IdUsuario equals u.idUsuario
                                   join b in db.Libroes on rb.IdLibro equals b.IdLibro
                                   select new PrestamoLibroViewModel
                                   {
                                        IdPrestamoLibro = rb.IdPrestamoLibro,
                                        IdLibro = b.IdLibro,
                                        Libro = b.NombreLibro,
                                        IdUsuario = u.idUsuario,
                                        Usuario = u.Nombres,
                                        FechaPrestamo = rb.FechaPrestamo,
                                        FueDvuelto = rb.FueDvuelto,
                                        ObservacionEntrega = rb.ObservacionEntrega,
                                        ObservacionPrestamo = rb.ObservacionPrestamo
                                   }).ToList();
                return RentedBooks;
            }
        }

        public bool CreateRentedBook(PrestamoLibro rentedBook)
        {
            try
            {
                using (BibliotecaEntities db = new BibliotecaEntities())
                {
                    db.PrestamoLibroes.Add(rentedBook);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PrestamoLibroViewModel FindRentedBookById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    var RentedBooks = (from rb in db.PrestamoLibroes
                                       join u in db.Usuarios on rb.IdUsuario equals u.idUsuario
                                       join b in db.Libroes on rb.IdLibro equals b.IdLibro
                                       where rb.IdPrestamoLibro == id
                                       select new PrestamoLibroViewModel
                                       {
                                           IdPrestamoLibro = rb.IdPrestamoLibro,
                                           IdLibro = b.IdLibro,
                                           Libro = b.NombreLibro,
                                           IdUsuario = u.idUsuario,
                                           Usuario = u.Nombres,
                                           FechaPrestamo = rb.FechaPrestamo,
                                           FueDvuelto = rb.FueDvuelto,
                                           ObservacionEntrega = rb.ObservacionEntrega,
                                           ObservacionPrestamo = rb.ObservacionPrestamo
                                       }).FirstOrDefault();
                    return RentedBooks;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditRentedBook(models.PrestamoLibro rentedBook)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(rentedBook).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteRentedBook(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.PrestamoLibro rentedBook = db.PrestamoLibroes.Find(id);
                    db.PrestamoLibroes.Remove(rentedBook);
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
