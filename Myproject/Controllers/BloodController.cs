using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myproject.Controllers
{
    public class BloodController : Controller
    {
        private Repository.BloodRepository bloodRepository = new Repository.BloodRepository();
        // GET: Blood
        public ActionResult Index()
        {
            List<Models.BloodModel> bloods = bloodRepository.GetAllBloods();
            return View("Index",bloods);
        }

        // GET: Blood/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blood/Create
        public ActionResult Create()
        {
            return View("CreateBlood");
        }

        // POST: Blood/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.BloodModel bloodModel = new Models.BloodModel();

                UpdateModel(bloodModel);

                bloodRepository.InsertBlood(bloodModel);

                return RedirectToAction("Index");
            }
            catch 
            {
                return View("CreateBlood");
            }
        }

        // GET: Blood/Edit/5
        public ActionResult Edit(Guid id)
        {
            Models.BloodModel bloodModel = bloodRepository.GetBloodByID(id);

            return View("EditBlood",bloodModel);
        }

        // POST: Blood/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.BloodModel bloodModel = new Models.BloodModel();

                UpdateModel(bloodModel);

                bloodRepository.UpdateBlood(bloodModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditBlood");
            }
        }

        // GET: Blood/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.BloodModel bloodModel = bloodRepository.GetBloodByID(id);
            return View("DeleteBlood",bloodModel);
        }

        // POST: Blood/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bloodRepository.DeleteBlood(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteBlood");
            }
        }
    }
}
