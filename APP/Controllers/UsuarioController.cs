using System;
using System.Web.Mvc;
using models.ViewModels;
using models;


namespace APP.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioBLL UsuarioBLL = new UsuarioBLL();
        // GET: Usuario
        public ActionResult List()
        {
            return View(UsuarioBLL.ListUsers());
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            var kindsOfIdentifications = new TipoIdentificacionBLL().ListTypeIdentification();
            var  list = new SelectList(kindsOfIdentifications, "IdTipoIdentificacion", "NombreTipoIdentificacion");
            ViewBag.TipoIdentificacionList = list;
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
                var model = new Usuario();
                model.Nombres = collection["Nombres"];
                model.Apellidos = collection["Apellidos"];
                model.NumeroIdentificacion = collection["NumeroIdentificacion"];
                model.CorreoElectronico = collection["CorreoElectronico"];
                model.FechaNacimiento = DateTime.Parse(collection["FechaNacimiento"]);
                model.Direccion = collection["Direccion"];
                model.Telefono = collection["Telefono"];
                model.PaisOrigen = collection["PaisOrigen"];
                model.IdTipoIdentificacion = Int32.Parse(collection["IdTipoIdentificacion"]);
                 Console.WriteLine(Int32.Parse(collection["IdTipoIdentificacion"]));
            Console.WriteLine(DateTime.Parse(collection["FechaNacimiento"]));
                if (UsuarioBLL.CreateUser(model)) {
                    return RedirectToAction("List");
                }
                return Redirect("Usuario/Create"+ collection["IdTipoIdentificacion"]+ collection["FechaNacimiento"]);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var kindsOfIdentifications = new TipoIdentificacionBLL().ListTypeIdentification();
            var list = new SelectList(kindsOfIdentifications, "IdTipoIdentificacion", "NombreTipoIdentificacion");
            ViewBag.TipoIdentificacionList = list;
            UsuarioViewModel usuario = UsuarioBLL.FindUserById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
                var model = new Usuario();
                model.idUsuario = id;
                model.Nombres = collection["Nombres"];
                model.Apellidos = collection["Apellidos"];
                model.NumeroIdentificacion = collection["NumeroIdentificacion"];
                model.CorreoElectronico = collection["CorreoElectronico"];
                model.FechaNacimiento = DateTime.Parse(collection["FechaNacimiento"]);
                model.Direccion = collection["Direccion"];
                model.Telefono = collection["Telefono"];
                model.PaisOrigen = collection["PaisOrigen"];
                model.IdTipoIdentificacion = Int32.Parse(collection["IdTipoIdentificacion"]);
                if (UsuarioBLL.EditUser(model))
                {
                    return RedirectToAction("List");
                }
                return Redirect("Usuario/Edit");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var usuario = UsuarioBLL.FindUserById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
 
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                UsuarioBLL.DeleteUser(id);
                return RedirectToAction("List");
        }
    }
}
