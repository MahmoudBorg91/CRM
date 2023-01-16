using GSI_Internal.Entites;
using System.Collections.Generic;


namespace GSI_Internal.Repositry.JopListRepo
{
    public interface IJopListRepocs
    {
        IEnumerable<JopList> GetAll();
        JopList GetByID(int id);
        JopList AddObj(JopList obj);
        JopList UpdateObj(JopList obj);
        JopList DeleteObj(int id);

    }
}
