using GSI_Internal.Entites;
using System.Collections.Generic;

namespace GSI_Internal.Repositry.OurCompanyInfoRepo
{
    public interface IOurCompanyInfoRepo
    {
        IEnumerable<OurCompanyInfo> GetAll();
        OurCompanyInfo GetByID(int id);
        OurCompanyInfo AddObj(OurCompanyInfo obj);
        OurCompanyInfo UpdateObj(OurCompanyInfo obj);
        OurCompanyInfo DeleteObj(int id);

    }
}
