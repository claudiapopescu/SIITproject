using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Myproject.Models;
using Myproject.Models.DBObjects;

namespace Myproject.Repository
{
    public class PatientRepository
    {
        private Models.DBObjects.MyProjectDataContext dbContext;

        public PatientRepository()
        { this.dbContext = new Models.DBObjects.MyProjectDataContext(); }

        public PatientRepository (Models.DBObjects.MyProjectDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PatientModel> GetAllPatients()

        {
            List<PatientModel> patientList = new List<PatientModel>();

            foreach(Models.DBObjects.Patient dbPatient in dbContext.Patients)
            {
                patientList.Add(MapDbObjectToModel(dbPatient));

            }
            return patientList;

        }

        public PatientModel GetPatientByID (Guid ID)
        {
            return MapDbObjectToModel(dbContext.Patients.FirstOrDefault(x => x.IDPatient == ID));
        }

        public List<PatientModel> GetPatientByName(string FirstName, string LastName)
        {
            List<PatientModel> patientList = new List<PatientModel>();

            foreach (Models.DBObjects.Patient dbPatient in dbContext.Patients.Where(x=> x.FirstName ==FirstName 
            && x.LastName==LastName))
            {
                patientList.Add(MapDbObjectToModel(dbPatient));
            }
            return patientList;
        }

        public void InsertPatient (PatientModel patientModel)
        {
            patientModel.IDPatient = Guid.NewGuid();
            dbContext.Patients.InsertOnSubmit(MapModelToDbObject(patientModel));
            dbContext.SubmitChanges();
        }

        public void UpdatePatient (PatientModel patientModel)
        {
            Models.DBObjects.Patient existingPatient = dbContext.Patients.FirstOrDefault(x => x.IDPatient == patientModel.IDPatient);

            if(existingPatient!=null)
            {
                existingPatient.IDPatient = patientModel.IDPatient;
                existingPatient.FirstName = patientModel.FirstName;
                existingPatient.LastName = patientModel.LastName;
                existingPatient.UserAddress = patientModel.UserAddress;
                existingPatient.PhoneNumber = patientModel.PhoneNumber;
                dbContext.SubmitChanges();
            }
        }

        public void DeletePatient(Guid ID)
        {
            Models.DBObjects.Patient patientToDelete = dbContext.Patients.FirstOrDefault(x => x.IDPatient == ID);
            
            if(patientToDelete!=null)
            {
                dbContext.Patients.DeleteOnSubmit(patientToDelete);
                dbContext.SubmitChanges();
            }
        }

        private PatientModel MapDbObjectToModel(Models.DBObjects.Patient dbPatient)
        {
            PatientModel patientModel = new PatientModel();

            if (dbPatient != null)
            {
                patientModel.IDPatient = dbPatient.IDPatient;
                patientModel.FirstName = dbPatient.FirstName;
                patientModel.LastName = dbPatient.LastName;
                patientModel.UserAddress = dbPatient.UserAddress;
                patientModel.PhoneNumber = dbPatient.PhoneNumber;

                return patientModel;
            }
            return null;
        }

        private Models.DBObjects.Patient MapModelToDbObject(PatientModel patientModel)
        {
            Models.DBObjects.Patient dbPatientModel = new Models.DBObjects.Patient();

            if (patientModel != null)
            {
                dbPatientModel.IDPatient = patientModel.IDPatient;
                dbPatientModel.FirstName = patientModel.FirstName;
                dbPatientModel.LastName = patientModel.LastName;
                dbPatientModel.UserAddress = patientModel.UserAddress;
                dbPatientModel.PhoneNumber = patientModel.PhoneNumber;

                return dbPatientModel;
            }
            return null;
        }
    }
    }
