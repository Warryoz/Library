using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.ViewModel
{
    public class TipoIdentificacionDAL
    {
        public List<models.TipoIdentificacion> ListTypeIdentification()
        {
            using (models.BibliotecaEntities db = new models.BibliotecaEntities())
            {
                return db.TipoIdentificacions.ToList();
            }
        }

        public bool CreateTypeIdentification(models.TipoIdentificacion typeIdentification)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.TipoIdentificacions.Add(typeIdentification);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public models.TipoIdentificacion FindTypeIdentificationById(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.TipoIdentificacion typeIdentification = db.TipoIdentificacions.Find(id);
                    db.SaveChanges();
                    return typeIdentification;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditTypeIdentification(models.TipoIdentificacion typeIdentification)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    db.Entry(typeIdentification).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTypeIdentification(int id)
        {
            try
            {
                using (models.BibliotecaEntities db = new models.BibliotecaEntities())
                {
                    models.TipoIdentificacion typeIdentification = db.TipoIdentificacions.Find(id);
                    db.TipoIdentificacions.Remove(typeIdentification);
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
