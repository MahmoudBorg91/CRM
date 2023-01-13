using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;

namespace GSI_Internal.Repositry.ContactUsRepo
{
    public class ContactUsRepo:IContatUsRepo
    {
        private readonly dbContainer _db;

        public ContactUsRepo(dbContainer db)
        {
            _db = db;
        }


        public IEnumerable<ContactUs> GetAll()
        {
            var data = _db.ContactUs.Select(a => a);
            return data;
        }

        public ContactUs GetByID(int id)
        {
            var data = _db.ContactUs.Find(id);
            return data;
        }

        public ContactUs AddObj(ContactUs obj)
        {
          var AddData = _db.ContactUs.Add(obj);
          _db.SaveChanges();
          return obj;
        }

        public ContactUs UpdateObj(ContactUs obj)
        {
            var EditData = _db.ContactUs.Find(obj.Id);
            EditData.Id = obj.Id;
            EditData.WhatsAppNumber = obj.WhatsAppNumber;
            EditData.Email = obj.Email;
            EditData.Link = obj.Link;
            EditData.FaceBookLink= obj.FaceBookLink;
            EditData.InstagramLink = obj.InstagramLink;
            EditData.TwitterLink = obj.TwitterLink;
            EditData.YouTubeLink = obj.YouTubeLink;
            EditData.LinkedInLink = obj.LinkedInLink;
            EditData.PhoneNumber= obj.PhoneNumber;
            EditData.Location = obj.Location;
            EditData.TermsAndConditions = obj.TermsAndConditions;
            EditData.TermsAndConditionsAr= obj.TermsAndConditionsAr;
            EditData.LocationAr = obj.LocationAr;
            EditData.PhoneNumber2=obj.PhoneNumber2;
            EditData.PrivacyAndPolicy = obj.PrivacyAndPolicy;
            EditData.PrivacyAndPolicyAr= obj.PrivacyAndPolicyAr;
            EditData.RefundPolicy= obj.RefundPolicy;
            EditData.RefundPolicyAr=obj.RefundPolicyAr;
            _db.SaveChanges();
            return EditData;


        }

        public ContactUs DeleteObj(int id)
        {
            var DeleteData = _db.ContactUs.Find(id);
            _db.ContactUs.Remove(DeleteData);
            _db.SaveChanges();
            return DeleteData;
        }
    }
}
