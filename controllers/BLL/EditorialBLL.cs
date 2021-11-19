using System.Collections.Generic;
using DAL.ViewModel;
using models;

public class EditorialBLL
{
    private EditorialDAL EditorialDAL = new EditorialDAL();
    public List<Editorial> ListEditorials()
    {
        return EditorialDAL.ListEditorials();
    }

    public bool CreateEditorial(models.Editorial editorial)
    {

        if (EditorialDAL.CreateEditorial(editorial))
        {
            return true;
        }
        return false;

    }

    public bool EditEditorial(Editorial editorial)
    {
        if (EditorialDAL.EditEditorial(editorial))
        {
            return true;
        }
        return false;

    }

    public models.Editorial FindEditorialById(int id)
    {
        return EditorialDAL.FindEditorialById(id);
    }

    public bool DeleteEditorial(int id)
    {

        if (EditorialDAL.DeleteEditorial(id))
        {
            return true;
        }
        return false;

    }
}
