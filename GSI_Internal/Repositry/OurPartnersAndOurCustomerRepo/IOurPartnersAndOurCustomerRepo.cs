using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.OurPartnersAndOurCustomerRepo
{
    public interface IOurPartnersAndOurCustomerRepo
    {
        IEnumerable<OurPartnersAndOurCustomer> GetAll();
        OurPartnersAndOurCustomer GetByID(int id);
        OurPartnersAndOurCustomer AddObj(OurPartnersAndOurCustomer obj);
        OurPartnersAndOurCustomer UpdateObj(OurPartnersAndOurCustomer obj);
        OurPartnersAndOurCustomer DeleteObj(int id);
    }
}
