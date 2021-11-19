using System;
using System.Web.Mvc;
using models;
namespace APP.Controllers
{
    public class PrestamoLibroController : Controller
    {
        private PrestamoLibroBLL PrestamoLibroBLL = new PrestamoLibroBLL();
        // GET: PrestamoLibro
        public ActionResult List()
        {
            return View(PrestamoLibroBLL.ListRentedBooks());
        }

        // GET: PrestamoLibro/Create
        public ActionResult Create()
        {
            var Users = new UsuarioBLL().ListUsers();
            var Books = new LibroBLL().ListActiveBooks();
            var UsersList = new SelectList(Users, "idUsuario", "Nombres");
            var BooksList = new SelectList(Books, "IdLibro", "NombreLibro");
            ViewBag.BooksList = BooksList;
            ViewBag.UsersList = UsersList;
            return View();
        }

        // POST: PrestamoLibro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new PrestamoLibro();
            model.FechaPrestamo = DateTime.Parse(collection["FechaPrestamo"]);
            model.IdLibro = Int32.Parse(collection["IdLibro"]);
            model.IdUsuario = Int32.Parse(collection["idUsuario"]);
            model.ObservacionPrestamo = collection["ObservacionPrestamo"];
            model.FueDvuelto = false;

            if (PrestamoLibroBLL.CreateRentedBook(model))
            {
                var BookBLL = new LibroBLL();
                if (BookBLL.DisableBook(model.IdLibro)) {
                    return RedirectToAction("List");
                }
            }
            return Redirect("PrestamoLibro/Create");
        }

        // GET: PrestamoLibro/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Users = new UsuarioBLL().ListUsers();
            var Books = new LibroBLL().ListBooks();
            var UsersList = new SelectList(Users, "idUsuario", "Nombres");
            var BooksList = new SelectList(Books, "IdLibro", "NombreLibro");
            ViewBag.BooksList = BooksList;
            ViewBag.UsersList = UsersList;
            var rentedBook = PrestamoLibroBLL.FindRentedBookById(id);
            if (rentedBook == null)
            {
                return HttpNotFound();
            }
            return View(rentedBook);
        }

        // POST: PrestamoLibro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new PrestamoLibro();
            model.IdPrestamoLibro = id;
            model.FechaPrestamo = DateTime.Parse(collection["FechaPrestamo"]);
            model.IdLibro = Int32.Parse(collection["IdLibro"]);
            model.IdUsuario = Int32.Parse(collection["IdUsuario"]);
            model.ObservacionEntrega = collection["ObservacionEntrega"];
            model.ObservacionPrestamo = collection["ObservacionPrestamo"];
            if (PrestamoLibroBLL.EditRentedBook(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("PrestamoLibro/Edit");
        }

        // GET: PrestamoLibro/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var rentedBook = PrestamoLibroBLL.FindRentedBookById(id);
            if (rentedBook == null)
            {
                return HttpNotFound();
            }
            return View(rentedBook);

        }

        // POST: PrestamoLibro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            PrestamoLibroBLL.DeleteRentedBook(id);
            return RedirectToAction("List");
        }
    }
}
