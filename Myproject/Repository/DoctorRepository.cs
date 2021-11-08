using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Myproject.Models.DBObjects;
using Myproject.Models;

namespace Myproject.Repository
{
    public class DoctorRepository
    {
        private Models.DBObjects.MyProjectDataContext dbContext;

        public DoctorRepository()
        { this.dbContext = new Models.DBObjects.MyProjectDataContext(); }

        public DoctorRepository(Models.DBObjects.MyProjectDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<DoctorModel> GetAllDoctors()

        {
            List<DoctorModel> doctorList = new List<DoctorModel>();

            foreach (Models.DBObjects.Doctor dbDoctor in dbContext.Doctors)
            {
                doctorList.Add(MapDbObjectToModel(dbDoctor));

            }
            return doctorList;

        }

        public DoctorModel GetDoctorByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Doctors.FirstOrDefault(x => x.IdDoctor == ID));
        }

        public List<DoctorModel> GetDoctorByName(string Name)
        {
            List<DoctorModel> doctorList = new List<DoctorModel>();

            foreach (Models.DBObjects.Doctor dbDoctor in dbContext.Doctors.Where(x => x.Name == Name))
            {
                doctorList.Add(MapDbObjectToModel(dbDoctor));
            }
            return doctorList;
        }

        public void InsertDoctor(DoctorModel doctorModel)
        {
            doctorModel.IdDoctor = Guid.NewGuid();
            dbContext.Doctors.InsertOnSubmit(MapModelToDbObject(doctorModel));
            dbContext.SubmitChanges();
        }

        public void UpdateDoctor(DoctorModel doctorModel)
        {
            Models.DBObjects.Doctor existingDoctor = dbContext.Doctors.FirstOrDefault(x => x.IdDoctor == doctorModel.IdDoctor);

            if (existingDoctor != null)
            {
                existingDoctor.IdDoctor = doctorModel.IdDoctor;
                existingDoctor.Name = doctorModel.Name;
                existingDoctor.DoctorCity = doctorModel.DoctorCity;
                existingDoctor.EmergencyPhone = doctorModel.EmergencyPhone;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteDoctor(Guid ID)
        {
            Models.DBObjects.Doctor doctorToDelete = dbContext.Doctors.FirstOrDefault(x => x.IdDoctor == ID);

            if (doctorToDelete != null)
            {
                dbContext.Doctors.DeleteOnSubmit(doctorToDelete);
                dbContext.SubmitChanges();
            }
        }

        private DoctorModel MapDbObjectToModel(Models.DBObjects.Doctor dbDoctor)
        {
            DoctorModel doctorModel = new DoctorModel();

            if (dbDoctor != null)
            {
                doctorModel.IdDoctor = dbDoctor.IdDoctor;
                doctorModel.Name = dbDoctor.Name;
                doctorModel.DoctorCity = dbDoctor.DoctorCity;
                doctorModel.EmergencyPhone = dbDoctor.EmergencyPhone;
              
                return doctorModel;
            }
            return null;
        }

        private Models.DBObjects.Doctor MapModelToDbObject(DoctorModel doctorModel)
        {
            Models.DBObjects.Doctor dbDoctorModel = new Models.DBObjects.Doctor();

            if (doctorModel != null)
            {
                dbDoctorModel.IdDoctor = doctorModel.IdDoctor;
                dbDoctorModel.Name = doctorModel.Name;
                dbDoctorModel.DoctorCity = doctorModel.DoctorCity;
                dbDoctorModel.EmergencyPhone = doctorModel.EmergencyPhone;
          
                return dbDoctorModel;
            }
            return null;
        }
    }
}
