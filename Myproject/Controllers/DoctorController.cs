using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myproject.Controllers
{
    public class DoctorController : Controller
    {
        private Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
        // GET: Doctor
        public ActionResult Index()
        {
            List<Models.DoctorModel> doctors = doctorRepository.GetAllDoctors();
            return View("Index",doctors);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(Guid id)
        {
            Models.DoctorModel doctorModel = doctorRepository.GetDoctorByID(id);
            return View("DoctorDetails",doctorModel);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View("CreateDoctor");
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.DoctorModel doctorModel = new Models.DoctorModel();

                UpdateModel(doctorModel);

                doctorRepository.InsertDoctor(doctorModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateDoctor");
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(Guid id)
        {
            Models.DoctorModel doctorModel = doctorRepository.GetDoctorByID(id);

            return View("EditDoctor",doctorModel);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.DoctorModel doctorModel = new Models.DoctorModel();
                UpdateModel(doctorModel);
                doctorRepository.UpdateDoctor(doctorModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditDoctor");
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.DoctorModel doctorModel = doctorRepository.GetDoctorByID(id);
            return View("DeleteDoctor",doctorModel);
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                doctorRepository.DeleteDoctor(id);

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteDoctor");
            }
        }
    }
}
