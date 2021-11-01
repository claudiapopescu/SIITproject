using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myproject.Controllers
{
    public class PatientController : Controller
    {
        private Repository.PatientRepository patientRepository = new Repository.PatientRepository();
        // GET: Patient
        public ActionResult Index()
        {
            List<Models.PatientModel> patients = patientRepository.GetAllPatients();
            return View("Index",patients);
        }

        // GET: Patient/Details/5
        public ActionResult Details(Guid id)
        {
            Models.PatientModel patientModel = patientRepository.GetPatientByID(id);
            return View("PatientDetails",patientModel);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View("CreatePatient");
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.PatientModel patientModel = new Models.PatientModel();
                UpdateModel(patientModel);
                patientRepository.InsertPatient(patientModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreatePatient");
            }
        }

        // GET: Patient/Edit/5
       
        public ActionResult Edit(Guid id)
        {
            Models.PatientModel patientModel = patientRepository.GetPatientByID(id);
            return View("EditPatient",patientModel);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            
            try
            {
                // TODO: Add update logic here
                Models.PatientModel patientModel = new Models.PatientModel();
                UpdateModel(patientModel);
                patientRepository.UpdatePatient(patientModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditPatient");
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.PatientModel patientModel = patientRepository.GetPatientByID(id);
            return View("DeletePatient",patientModel);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                patientRepository.DeletePatient(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePatient");
            }
        }
    }
}
