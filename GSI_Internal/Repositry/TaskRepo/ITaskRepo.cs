using System.Collections;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.TaskRepo
{
    public interface ITaskRepo
    {
        Task <IEnumerable <TaskMain>>  GetAllAsync();
        Task<TaskMain>  GetByIdAsync(int id);
        TaskMain AddObj(TaskMain obj);
        Task<TaskMain> UpdateObj(TaskMain obj);
        Task<TaskMain> DeleteObj(int id);
    }
}
