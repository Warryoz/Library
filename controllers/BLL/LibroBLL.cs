using System.Collections.Generic;
using DAL.ViewModel;
using models;
using models.ViewModels;

public class LibroBLL
{
    private LibroDAL LibroDAL = new LibroDAL();
    public List<LibroViewModel> ListBooks()
    {
        return LibroDAL.ListBooks();
    }

    public bool CreateBook(Libro book)
    {

        if (LibroDAL.CreateBook(book))
        {
            return true;
        }
        return false;

    }

    public bool EditBook(Libro book)
    {
        if (LibroDAL.EditBook(book))
        {
            return true;
        }
        return false;

    }

    public LibroViewModel FindBookById(int id)
    {
        return LibroDAL.FindBookById(id);
    }

    public bool DeleteBook(int id)
    {

        if (LibroDAL.DeleteBook(id))
        {
            return true;
        }
        return false;

    }

    public List<LibroViewModel> ListActiveBooks()
    {
        return LibroDAL.ListActiveBooks();
    }

    public bool DisableBook(int id)
    { 
        if (LibroDAL.DisableBook(id))
        {
            return true;
        }
        return false;

    }
}
