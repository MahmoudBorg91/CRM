using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestInquiry_AnswerRepo
{
    public interface IRequestInquiry_AnswerRpo
    {
        IEnumerable<RequestInquiry_Answer> GetAll();
    }
}
