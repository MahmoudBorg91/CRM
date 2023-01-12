using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.ContactUsRepo
{
    public interface IContatUsRepo
    {
        IEnumerable<ContactUs> GetAll();
        ContactUs GetByID(int id);
        ContactUs AddObj(ContactUs obj);
        ContactUs UpdateObj(ContactUs obj);
        ContactUs DeleteObj(int id);
    }
}
