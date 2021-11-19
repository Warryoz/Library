using System.Collections.Generic;
using DAL.ViewModel;
using models;

public class AutorBLL
{
    private AutorDAL AutorDAL = new AutorDAL();
    public List<Autor> ListAuthors()
    {
        return AutorDAL.ListAuthors();
    }

    public bool CreateAuthor(models.Autor author)
    {

        if (AutorDAL.CreateAuthor(author))
        {
            return true;
        }
        return false;

    }

    public bool EditAuthor(models.Autor author)
    {
        if (AutorDAL.EditAuthor(author))
        {
            return true;
        }
        return false;

    }

    public models.Autor FindAuthorById(int id)
    {
        return AutorDAL.FindAuthorById(id);
    }

    public bool DeleteAuthor(int id)
    {

        if (AutorDAL.DeleteAuthor(id))
        {
            return true;
        }
        return false;

    }
}
