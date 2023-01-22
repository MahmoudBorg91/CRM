using System.Collections;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.TaskDocuments
{
    public interface ITaskDocument_Repo
    {
        IEnumerable<TaskDocuments_tbl> GetAllAsync();
        TaskDocuments_tbl GetByIdAsync(int id);
        TaskDocuments_tbl AddObj(TaskDocuments_tbl obj);
        Task<TaskDocuments_tbl> UpdateObj(TaskDocuments_tbl obj);
        Task<TaskDocuments_tbl> DeleteObj(int id);
    }
}
