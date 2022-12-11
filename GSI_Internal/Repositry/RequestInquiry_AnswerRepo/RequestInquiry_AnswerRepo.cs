using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestInquiry_AnswerRepo
{
    public class RequestInquiry_AnswerRepo:IRequestInquiry_AnswerRpo
    {
        private readonly dbContainer db;
        public RequestInquiry_AnswerRepo(dbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<RequestInquiry_Answer> GetAll()
        {
            var date = db.RequestInquiry_Answer.Select(a => a);
            return date.ToList();
        }
    }
}
