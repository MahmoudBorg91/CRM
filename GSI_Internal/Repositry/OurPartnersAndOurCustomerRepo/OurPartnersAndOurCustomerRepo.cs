using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.OurPartnersAndOurCustomerRepo
{
    public class OurPartnersAndOurCustomerRepo : IOurPartnersAndOurCustomerRepo
    {
        private readonly dbContainer _db;

        public OurPartnersAndOurCustomerRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<OurPartnersAndOurCustomer> GetAll()
        {
            var data = _db.OurPartnersAndOurCustomer.Select(a => a);
            return data;
        }

        public OurPartnersAndOurCustomer GetByID(int id)
        {
            var data = _db.OurPartnersAndOurCustomer.Find(id);
            return data;
        }

        public OurPartnersAndOurCustomer AddObj(OurPartnersAndOurCustomer obj)
        {
            var data = _db.OurPartnersAndOurCustomer.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public OurPartnersAndOurCustomer UpdateObj(OurPartnersAndOurCustomer obj)
        {
            var EditData = _db.OurPartnersAndOurCustomer.Find(obj.ID);
            EditData.ID = obj.ID;
            EditData.NameAr = obj.NameAr;
            EditData.NameEnglish = obj.NameEnglish;
            EditData.NoteAr = obj.NameAr;
            EditData.NoteEng = obj.NoteEng;
            EditData.IsPartners = obj.IsPartners;
            _db.SaveChanges();
            return EditData;






        }

        public OurPartnersAndOurCustomer DeleteObj(int id)
        {
            var DeleteData = _db.OurPartnersAndOurCustomer.Find(id);
            _db.OurPartnersAndOurCustomer.Remove(DeleteData);
            _db.SaveChanges();
            return DeleteData;

        }
    }
}
