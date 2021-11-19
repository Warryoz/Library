using System.Web.Mvc;
using models;

namespace APP.Controllers
{
    public class TipoidentificacionController : Controller
    {
        private TipoIdentificacionBLL TipoIdentificacionBLL = new TipoIdentificacionBLL();
        // GET: TypeIdentification
        public ActionResult List()
        {
            return View(TipoIdentificacionBLL.ListTypeIdentification());
        }

        // GET: TypeIdentification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeIdentification/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new TipoIdentificacion();
            model.NombreTipoIdentificacion = collection["NombreTipoIdentificacion"];
            if (TipoIdentificacionBLL.CreateTypeIdentification(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("TipoIdentificacion/Create");
        }

        // GET: TypeIdentification/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            models.TipoIdentificacion TypeIdentification = TipoIdentificacionBLL.FindTypeIdentificationById(id);
            if (TypeIdentification == null)
            {
                return HttpNotFound();
            }
            return View(TypeIdentification);
        }

        // POST: TypeIdentification/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new TipoIdentificacion();
            model.IdTipoIdentificacion = id;
            model.NombreTipoIdentificacion = collection["NombreTipoIdentificacion"];
            if (TipoIdentificacionBLL.EditTypeIdentification(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("TipoIdentificacion/Edit");
        }

        // GET: TypeIdentification/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var TypeIdentification = TipoIdentificacionBLL.FindTypeIdentificationById(id);
            if (TypeIdentification == null)
            {
                return HttpNotFound();
            }
            return View(TypeIdentification);

        }

        // POST: TypeIdentification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            TipoIdentificacionBLL.DeleteTypeIdentification(id);
            return RedirectToAction("List");
        }
    }
}
