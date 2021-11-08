using Myproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myproject.Repository
{
    public class BloodRepository
    {
        private Models.DBObjects.MyProjectDataContext dbContext;

        public BloodRepository()
        { 
            this.dbContext = new Models.DBObjects.MyProjectDataContext();
        }
        public BloodRepository(Models.DBObjects.MyProjectDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BloodModel> GetAllBloods()
        {
            List<BloodModel> bloodList = new List<BloodModel>();

            foreach (Models.DBObjects.Blood dbBlood in dbContext.Bloods)
            {
                bloodList.Add(MapDbObjectToModel(dbBlood));
            }
            return bloodList;
        }

        public BloodModel GetBloodByID (Guid ID)
        {
            return MapDbObjectToModel(dbContext.Bloods.FirstOrDefault(x => x.IdBlood == ID));
        }

        public List<BloodModel> GetBloodsByType (string Type)
        {
            List<BloodModel> bloodList = new List<BloodModel>();

            foreach (Models.DBObjects.Blood dbBlood in dbContext.Bloods.Where(x=>x.Type ==Type))
            {
                bloodList.Add(MapDbObjectToModel(dbBlood));
            }
            return bloodList;
        }

        public List<BloodModel> GetBloodsByRhType(string RHType)
        {
            List<BloodModel> bloodList = new List<BloodModel>();

            foreach (Models.DBObjects.Blood dbBlood in dbContext.Bloods.Where(x => x.RhType == RHType))
            {
                bloodList.Add(MapDbObjectToModel(dbBlood));
            }
            return bloodList;
        }

        public List<BloodModel> GetBloodsByEntryDate(DateTime date)
        {
            List<BloodModel> bloodList = new List<BloodModel>();

            foreach (Models.DBObjects.Blood dbBlood in dbContext.Bloods.Where(x => x.EntryDate >= date))
            {
                bloodList.Add(MapDbObjectToModel(dbBlood));
            }
            return bloodList;
        }

        public List<BloodModel> GetBloodsByLocation(string location)
        {
            List<BloodModel> bloodList = new List<BloodModel>();

            foreach (Models.DBObjects.Blood dbBlood in dbContext.Bloods.Where(x => x.BloodLocation ==location))
            {
                bloodList.Add(MapDbObjectToModel(dbBlood));
            }
            return bloodList;
        }

        public void InsertBlood (BloodModel bloodModel)
        {
            bloodModel.IdBlood = Guid.NewGuid();
            dbContext.Bloods.InsertOnSubmit(MapModelToDbObject(bloodModel));
            dbContext.SubmitChanges();
        }

        public void UpdateBlood (BloodModel bloodModel)
        {
            Models.DBObjects.Blood existingBlood = dbContext.Bloods.FirstOrDefault(x => x.IdBlood == bloodModel.IdBlood);

            if (existingBlood!= null)
            { 
                existingBlood.IdBlood = bloodModel.IdBlood;
                existingBlood.Type = bloodModel.Type;
                existingBlood.RhType = bloodModel.RhType;
                existingBlood.Stock = bloodModel.Stock;
                existingBlood.BloodLocation = bloodModel.BloodLocation;
                existingBlood.EntryDate = bloodModel.EntryDate;
                existingBlood.LinkToTests = bloodModel.LinkToTests;
                dbContext.SubmitChanges();

            }
        }

        public void DeleteBlood(Guid ID)
        {
            Models.DBObjects.Blood bloodToDelete = dbContext.Bloods.FirstOrDefault(x => x.IdBlood == ID);

                if (bloodToDelete != null)
            { 
                dbContext.Bloods.DeleteOnSubmit(bloodToDelete);
                dbContext.SubmitChanges();

            }
        }

        private BloodModel MapDbObjectToModel (Models.DBObjects.Blood dbBlood)
        {
            BloodModel bloodModel = new BloodModel();

            if (dbBlood!=null)
            {
                bloodModel.IdBlood = dbBlood.IdBlood;
                bloodModel.Type = dbBlood.Type;
                bloodModel.RhType = dbBlood.RhType;
                bloodModel.BloodLocation = dbBlood.BloodLocation;
                bloodModel.Stock = dbBlood.Stock;
                bloodModel.EntryDate = dbBlood.EntryDate;
                bloodModel.LinkToTests = dbBlood.LinkToTests;

                return bloodModel;
            }
            return null;

        }

        private Models.DBObjects.Blood MapModelToDbObject (BloodModel bloodModel)
        {
            Models.DBObjects.Blood dbBloodModel = new Models.DBObjects.Blood();

            if ( bloodModel!=null)
            {
                dbBloodModel.IdBlood = bloodModel.IdBlood;
                dbBloodModel.Type = bloodModel.Type;
                dbBloodModel.RhType = bloodModel.RhType;
                dbBloodModel.Stock = bloodModel.Stock;
                dbBloodModel.EntryDate = bloodModel.EntryDate;
                dbBloodModel.LinkToTests = bloodModel.LinkToTests;

                return dbBloodModel;
            }

            return null;
        }
    }
}