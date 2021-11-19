using System;
using System.Collections.Generic;
using DAL.ViewModel;
using models;

public class TipoIdentificacionBLL
{
    private TipoIdentificacionDAL TipoIdentificacionDAL = new TipoIdentificacionDAL();
    public List<TipoIdentificacion> ListTypeIdentification()
    {
        return TipoIdentificacionDAL.ListTypeIdentification();
    }

    public bool CreateTypeIdentification(TipoIdentificacion typeIdentification)
    {

        if (TipoIdentificacionDAL.CreateTypeIdentification(typeIdentification))
        {
            return true;
        }
        return false;

    }

    public bool EditTypeIdentification(TipoIdentificacion typeIdentification)
    {
        if (TipoIdentificacionDAL.EditTypeIdentification(typeIdentification))
        {
            return true;
        }
        return false;

    }

    public models.TipoIdentificacion FindTypeIdentificationById(int id)
    {
        return TipoIdentificacionDAL.FindTypeIdentificationById(id);
    }

    public bool DeleteTypeIdentification(int id)
    {

        if (TipoIdentificacionDAL.DeleteTypeIdentification(id))
        {
            return true;
        }
        return false;

    }
}
