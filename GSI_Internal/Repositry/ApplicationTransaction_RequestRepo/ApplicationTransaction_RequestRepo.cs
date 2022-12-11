using GSI_Internal.Context;
using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GSI_Internal.Repositry.ApplicationTransaction_RequestRepo
{
    public class ApplicationTransaction_RequestRepo : IApplicationTransaction_RequestRepo
    {
        private readonly dbContainer db;

        public ApplicationTransaction_RequestRepo(dbContainer db)
        {
            this.db = db;
        }
        public ApplicationTransaction_Request AddObj(ApplicationTransaction_Request obj)
        {
            db.ApplicationTransaction_Request.Add(obj);
             db.SaveChanges();
            return obj;
        }

        public async Task<ApplicationTransaction_Request_Processing> UpdateRequestToProcess(ApplicationTransaction_Request_Processing obj)
        {
            db.ApplicationTransaction_Request_Processing.Add(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        //public Task<ApplicationTransaction_Request_Processing> UpdateRequestToTakeAction(ApplicationTransaction_Request_Processing obj)
        //{
        //    var updatedata=   db.ApplicationTransaction_Request_Processing.Find(obj.ID);
        //    updatedata.
        //    db.ApplicationTransaction_Request_Processing
        //}

        public IEnumerable<ApplicationTransaction_Request> GetAll()
        {
            var data = db.ApplicationTransaction_Request.Select(a => a);
            return data;
        }

        public ApplicationTransaction_Request_Processing GetAllProcessingByAppId(Guid AppID)
        {
            var data = db.ApplicationTransaction_Request_Processing.Where(a => a.App_Code == AppID)
                .Select(a => a).FirstOrDefault();
            return data;
        }

        public IEnumerable<ApplicationTransaction_Request_Processing> GetAllProcessing()
        {
            var data = db.ApplicationTransaction_Request_Processing.Select(a => a);
            return data;
        }

        public ApplicationTransaction_Request GetByID(int id)
        {
            var data = db.ApplicationTransaction_Request.Find(id);
            return data;

        }

        

        public async Task<ApplicationTransaction_Request> UpdateObjToSubmation(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 1;
            await db.SaveChangesAsync();
            return obj;
        }






        public async Task<ApplicationTransaction_Request> UpdateObjToPayment(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 2;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateObjToPaymentDone(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 3;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusUnderProcessing(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 4;
            Updatedata.NumberOfTransiactionOfEntity = obj.NumberOfTransiactionOfEntity;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusToDone(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 5;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusToMissingInformation(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 6;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusToMissingProcessing(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 7;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusRejectFromUS(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 8;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusRejectFromEntity(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.Status = 9;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateStatusToTransfer(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.TransferUserTo = obj.TransferUserTo;
            Updatedata.TarnferUserFrom = obj.TarnferUserFrom;
            Updatedata.Status = 10;
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<ApplicationTransaction_Request> UpdateApplicationToNewProcess(ApplicationTransaction_Request obj)
        {
            var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
            Updatedata.UserProsessID = obj.UserProsessID;
            Updatedata.IsProsessByUser=obj.IsProsessByUser;
            Updatedata.ProsessID = obj.ProsessID;
           
            await db.SaveChangesAsync();
            return obj;
        }

        public ApplicationTransaction_Request EditObj(ApplicationTransaction_Request obj)
        {
           var editdata = db.ApplicationTransaction_Request.Find(obj.ID);
           editdata.ID = obj.ID;
           editdata.Move_Type = obj.Move_Type;
           editdata.The_Date = obj.The_Date;
           editdata.ClientID = obj.ClientID;
           editdata.ClientName = obj.ClientName;
           editdata.ClientLastName=obj.ClientLastName;
           editdata.ClientPhone = obj.ClientPhone;
           editdata.UserEmail=obj.UserEmail;
           editdata.Country_Name = obj.Country_Name;
           editdata.TransiactionItem_Code=obj.TransiactionItem_Code;
           editdata.TransiactionItem_Name = obj.TransiactionItem_Name;
           editdata.TransiactionItem_GovernmentFees = obj.TransiactionItem_GovernmentFees;
           editdata.TransiactionItem_Price = obj.TransiactionItem_Price;
           editdata.TransiactionItem_Net=obj.TransiactionItem_Net;
           editdata.files = obj.files;
           editdata.Status=obj.Status;
           editdata.ClientNotes=obj.ClientNotes;
           editdata.NumberOfTransiactionOfEntity=obj.NumberOfTransiactionOfEntity;
           editdata.TarnferUserFrom=obj.TarnferUserFrom;
           editdata.TransferUserTo = obj.TransferUserTo;
           editdata.IsProsessByUser = obj.IsProsessByUser;
           editdata.UserProsessID=obj.UserProsessID;
           editdata.ProsessID = obj.ProsessID;
           db.SaveChanges();
           return obj;


        }

        //public async Task<ApplicationTransaction_Request> UpdateApplictionToProcessing(ApplicationTransaction_Request obj)
        //{

        //    var Updatedata = db.ApplicationTransaction_Request.Find(obj.ID);
        //    Updatedata.IsProsessByUser = obj.IsProsessByUser;
        //    Updatedata.UserProsessID = obj.UserProsessID;
        //    Updatedata.StartProcessingTime = obj.StartProcessingTime;
        //    await db.SaveChangesAsync();
        //    return obj;
        //}
    }
}
