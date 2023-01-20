using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Repositry.TaskProcessingRepo
{
    public class TaskProcessingRepo:ITaskProcessingRepo
    {
        private readonly dbContainer _db;


        public TaskProcessingRepo(dbContainer db)
        {
            _db = db;
        }
       

        public async Task<TasksProcessing> AddObj(TasksProcessing obj)
        {
            _db.TasksProcessing.Add(obj);
           await _db.SaveChangesAsync();
            return obj;
        }

        public IEnumerable<TasksProcessing> GetByTaskCode(int TaskID)
        {
            var data = _db.TasksProcessing.Select(a=>a);
            return data;
        }
    }
}
