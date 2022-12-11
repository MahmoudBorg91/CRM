using GSI_Internal.Entites;
using System.Collections.Generic;
namespace GSI_Internal.Repositry.AssignRequirmentToItemRepo
{
    public interface IAssignRequirmentToItemRepo
    {
        IEnumerable<AssignRequirmentToItem> GetAll();
        AssignRequirmentToItem GetById(int id);
        AssignRequirmentToItem AddObj(AssignRequirmentToItem obj);
        AssignRequirmentToItem UpdateObj(AssignRequirmentToItem obj);
        AssignRequirmentToItem DeleteObj(int id);
    }
}
