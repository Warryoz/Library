using System.Collections.Generic;
using DAL.ViewModel;
using models.ViewModels;

public class PrestamoLibroBLL
{
    private PrestamoLibroDAL PrestamoLibroDAL = new PrestamoLibroDAL();
    public List<PrestamoLibroViewModel> ListRentedBooks()
    {
        return PrestamoLibroDAL.ListRentedBooks();
    }

    public bool CreateRentedBook(models.PrestamoLibro rentedBook)
    {

        if (PrestamoLibroDAL.CreateRentedBook(rentedBook))
        {
            return true;
        }
        return false;

    }

    public bool EditRentedBook(models.PrestamoLibro rentedBook)
    {
        if (PrestamoLibroDAL.EditRentedBook(rentedBook))
        {
            return true;
        }
        return false;

    }

    public PrestamoLibroViewModel FindRentedBookById(int id)
    {
        return PrestamoLibroDAL.FindRentedBookById(id);
    }

    public bool DeleteRentedBook(int id)
    {

        if (PrestamoLibroDAL.DeleteRentedBook(id))
        {
            return true;
        }
        return false;

    }
}
