using System.Collections;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.TaskDocuments
{
    public interface ITaskDocument_Repo
    {
        Task<IEnumerable<TaskDocuments>> GetAllAsync();
        Task<TaskDocuments> GetByIdAsync(int id);
        Task<TaskDocuments> AddObj(TaskMain obj);
        Task<TaskDocuments> UpdateObj(TaskDocuments obj);
        Task<TaskDocuments> DeleteObj(int id);
    }
}
