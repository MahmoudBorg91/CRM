using GSI_Internal.Entites;
using System.Collections.Generic;
namespace GSI_Internal.Repositry.RequirementsRepo
{
    public interface IRequirementsRepo
    {
        IEnumerable<Requirements> GetAll();
        Requirements GetByID(int id);
        Requirements AddObj(Requirements obj);
        Requirements UpdateObj(Requirements obj);
        Requirements DeleteObj(int id);
    }
}
