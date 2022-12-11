using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestSelection_SelectedRepo
{
    public interface IRequestSelection_Selectes
    {
        IEnumerable<RequestSelection> GetAll();
    }
}
