using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.AssignInquireytToItemRepo
{
    public interface IAssignInquireytToItemRepo
    {
        IEnumerable<AssignInquiryToItem> GetAll();
    }
}
