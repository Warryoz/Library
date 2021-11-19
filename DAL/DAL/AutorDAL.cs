using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.ViewModel
{
    public class AutorDAL
    {
        public List<models.Autor> ListAuthors()
        {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                return db.Autors.ToList();
            }
        }

        public bool CreateAuthor(models.Autor author)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Autors.Add(author);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public models.Autor FindAuthorById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.Autor author = db.Autors.Find(id);
                    db.SaveChanges();
                    return author;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditAuthor(models.Autor author)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(author).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAuthor(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.Autor author = db.Autors.Find(id);
                    db.Autors.Remove(author);
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
