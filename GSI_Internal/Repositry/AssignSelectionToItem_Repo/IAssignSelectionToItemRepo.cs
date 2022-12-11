using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.AssignSelectionToItem_Repo
{
    public interface IAssignSelectionToItemRepo
    {
        IEnumerable<AssignSelectionToItem> GetAll();
    }
}
