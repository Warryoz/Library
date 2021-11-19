using System;
using System.Web.Mvc;
using models;

namespace APP.Controllers
{
    public class LibroController : Controller
    {
        private LibroBLL LibroBLL = new LibroBLL();
        // GET: Libro
        public ActionResult List()
        {
            return View(LibroBLL.ListBooks());
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            var Authors = new AutorBLL().ListAuthors();
            var Editorials = new EditorialBLL().ListEditorials();
            var AuthorsList = new SelectList(Authors, "IdAutor", "NombreAutor");
            var EditorialsList = new SelectList(Editorials, "IdEditorial", "NombreEditorial");
            ViewBag.Authors = AuthorsList;
            ViewBag.Editorials = EditorialsList;
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {   
            var model = new Libro();
            model.NombreLibro = collection["NombreLibro"];
            model.IdEditorial = Int32.Parse(collection["IdEditorial"]);
            model.IdAutor = Int32.Parse(collection["IdAutor"]);
            model.FechaLanzamiento = DateTime.Parse(collection["FechaLanzamiento"]);
            model.CantidadPaginas = collection["CantidadPaginas"];
            model.Disponible = true;
            if (LibroBLL.CreateBook(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("Libro/Create");
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Authors = new AutorBLL().ListAuthors();
            var Editorials = new EditorialBLL().ListEditorials();
            var AuthorsList = new SelectList(Authors, "IdAutor", "NombreAutor");
            var EditorialsList = new SelectList(Editorials, "IdEditorial", "NombreEditorial");
            ViewBag.Authors = AuthorsList;
            ViewBag.Editorials = EditorialsList;
            var Book = LibroBLL.FindBookById(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return View(Book);
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new Libro();
            model.IdLibro = id;
            model.NombreLibro = collection["NombreLibro"];
            model.IdEditorial = Int32.Parse(collection["IdEditorial"]);
            model.IdAutor = Int32.Parse(collection["IdAutor"]);
            model.Disponible = bool.Parse(collection["Disponible"]); 
            model.FechaLanzamiento = DateTime.Parse(collection["FechaLanzamiento"]);
            model.CantidadPaginas = collection["CantidadPaginas"];
            if (LibroBLL.EditBook(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("PrestamoLibro/Edit");
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var rentedBook = LibroBLL.FindBookById(id);
            if (rentedBook == null)
            {
                return HttpNotFound();
            }
            return View(rentedBook);

        }

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            LibroBLL.DeleteBook(id);
            return RedirectToAction("List");
        }
    }
}
