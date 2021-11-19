using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.ViewModel
{
    public class EditorialDAL
    {
        public List<models.Editorial> ListEditorials()
        {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                return db.Editorials.ToList();
            }
        }

        public bool CreateEditorial(models.Editorial editorial)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Editorials.Add(editorial);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public models.Editorial FindEditorialById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.Editorial editorial = db.Editorials.Find(id);
                    db.SaveChanges();
                    return editorial;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditEditorial(models.Editorial editorial)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(editorial).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteEditorial(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.Editorial editorial = db.Editorials.Find(id);
                    db.Editorials.Remove(editorial);
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
