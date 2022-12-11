using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TransiactionItem_Selection_Repo
{
    public interface ITransiactionItem_SelectionRepo
    {
        IEnumerable<TransiactionItem_Selection> GetAll();
        TransiactionItem_Selection GetByID(int id);
        TransiactionItem_Selection AddObj(TransiactionItem_Selection obj);
        TransiactionItem_Selection UpdateObj(TransiactionItem_Selection obj);
        TransiactionItem_Selection DeleteObj(int id);
    }
}
