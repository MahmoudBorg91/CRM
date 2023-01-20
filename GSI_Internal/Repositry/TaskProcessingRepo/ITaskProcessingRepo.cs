using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TaskProcessingRepo
{
    public interface ITaskProcessingRepo
    {
        Task<TasksProcessing> AddObj(TasksProcessing obj);

        IEnumerable<TasksProcessing> GetByTaskCode(int TaskID);
    }
}
