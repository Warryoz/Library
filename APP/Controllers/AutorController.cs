using System;
using System.Web.Mvc;
using models;

namespace APP.Controllers
{
    public class AutorController : Controller
    {
        private AutorBLL AutorBLL = new AutorBLL();
        // GET: Autor
        public ActionResult List()
        {
            return View(AutorBLL.ListAuthors());
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Autor();
            model.NombreAutor = collection["NombreAutor"];
            model.FechaNacimiento = DateTime.Parse(collection["FechaNacimiento"]);
            model.PaisOrigen = collection["PaisOrigen"];

            if (AutorBLL.CreateAuthor(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("Autor/Create");
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            models.Autor Author = AutorBLL.FindAuthorById(id);
            if (Author == null)
            {
                return HttpNotFound();
            }
            return View(Author);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new Autor();
            model.IdAutor = id;
            model.NombreAutor = collection["NombreAutor"];
            model.FechaNacimiento = DateTime.Parse(collection["FechaNacimiento"]);
            model.PaisOrigen = collection["PaisOrigen"];

            if (AutorBLL.EditAuthor(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("Autor/Edit");
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Author = AutorBLL.FindAuthorById(id);
            if (Author == null)
            {
                return HttpNotFound();
            }
            return View(Author);

        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            AutorBLL.DeleteAuthor(id);
            return RedirectToAction("List");
        }
    }
}
