using models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.ViewModel
{
    public class LibroDAL
    {
        public List<LibroViewModel> ListBooks()
        {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                var Books = (from b in db.Libroes 
                            join au in db.Autors on  b.IdAutor equals au.IdAutor
                            join edi in db.Editorials on b.IdEditorial equals edi.IdEditorial
                            select new LibroViewModel
                            {
                                IdLibro = b.IdLibro,
                                IdAutor = b.IdAutor,
                                Autor = au.NombreAutor,
                                Editorial = edi.NombreEditorial,
                                IdEditorial = b.IdEditorial,
                                NombreLibro = b.NombreLibro,
                                FechaLanzamiento = b.FechaLanzamiento,
                                Disponible = b.Disponible,
                                CantidadPaginas = b.CantidadPaginas
                            }).ToList();
                return Books;
            }
        }

        public bool CreateBook(models.Libro book)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Libroes.Add(book);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LibroViewModel FindBookById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    var Book = (from b in db.Libroes
                                 join au in db.Autors on b.IdAutor equals au.IdAutor
                                 join edi in db.Editorials on b.IdEditorial equals edi.IdEditorial
                                 where b.IdLibro == id
                                 select new LibroViewModel
                                 {
                                     IdLibro = b.IdLibro,
                                     IdAutor = b.IdAutor,
                                     Autor = au.NombreAutor,
                                     Editorial = edi.NombreEditorial,
                                     IdEditorial = b.IdEditorial,
                                     NombreLibro = b.NombreLibro,
                                     FechaLanzamiento = b.FechaLanzamiento,
                                     Disponible = b.Disponible,
                                     CantidadPaginas = b.CantidadPaginas
                                 }).FirstOrDefault();
                    return Book;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditBook(models.Libro book)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteBook(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.Libro book = db.Libroes.Find(id);
                    db.Libroes.Remove(book);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LibroViewModel> ListActiveBooks()
        {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                var Books = (from b in db.Libroes
                             join au in db.Autors on b.IdAutor equals au.IdAutor
                             join edi in db.Editorials on b.IdEditorial equals edi.IdEditorial
                             where b.Disponible == true
                             select new LibroViewModel
                             {
                                 IdLibro = b.IdLibro,
                                 IdAutor = b.IdAutor,
                                 Autor = au.NombreAutor,
                                 Editorial = edi.NombreEditorial,
                                 IdEditorial = b.IdEditorial,
                                 NombreLibro = b.NombreLibro,
                                 FechaLanzamiento = b.FechaLanzamiento,
                                 Disponible = b.Disponible,
                                 CantidadPaginas = b.CantidadPaginas
                             }).ToList();
                return Books;
            }
        }

        public bool DisableBook(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    var disableBook = (from b in db.Libroes
                                       where b.IdLibro == id
                                       select b).FirstOrDefault();
                    disableBook.Disponible = false;
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
