using System.Collections;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.TaskRepo
{
    public interface ITaskRepo
    {
        IEnumerable <TaskMain>  GetAllAsync();
        TaskMain GetByIdAsync(int id);
        TaskMain AddObj(TaskMain obj);
        Task<TaskMain> UpdateObj(TaskMain obj);
        Task<TaskMain> DeleteObj(int id);
        Task<TaskMain> UpdateTaskToUnderProcessing(TaskMain obj); // 1
        Task<TaskMain> UpdateTaskToReturn(TaskMain obj); // 2
        Task<TaskMain> UpdateTaskToFinish(TaskMain obj); //3
        Task<TaskMain> UpdateTaskToArchive(TaskMain obj); // 4

        string GetStatusName(int StatusID);
        string GetPriorityName(int StatusID);

    }
}
