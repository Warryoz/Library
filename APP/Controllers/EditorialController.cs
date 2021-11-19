using System.Web.Mvc;
using models;

namespace APP.Controllers
{
    public class EditorialController : Controller
    {
        private EditorialBLL EditorialBLL = new EditorialBLL();
        // GET: Editorial
        public ActionResult List()
        {
            return View(EditorialBLL.ListEditorials());
        }

        // GET: Editorial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Editorial();
            model.NombreEditorial = collection["NombreEditorial"];
            if (EditorialBLL.CreateEditorial(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("Editorial/Create");
        }

        // GET: Editorial/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            models.Editorial Editorial = EditorialBLL.FindEditorialById(id);
            if (Editorial == null)
            {
                return HttpNotFound();
            }
            return View(Editorial);
        }

        // POST: Editorial/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new Editorial();
            model.IdEditorial = id;
            model.NombreEditorial= collection["NombreEditorial"];

            if (EditorialBLL.EditEditorial(model))
            {
                return RedirectToAction("List");
            }
            return Redirect("Editorial/Edit");
        }

        // GET: Editorial/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Editorial = EditorialBLL.FindEditorialById(id);
            if (Editorial == null)
            {
                return HttpNotFound();
            }
            return View(Editorial);

        }

        // POST: Editorial/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            EditorialBLL.DeleteEditorial(id);
            return RedirectToAction("List");
        }
    }
}
