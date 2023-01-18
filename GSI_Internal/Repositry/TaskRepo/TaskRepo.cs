using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TaskRepo
{
    public class TaskRepo : ITaskRepo
    {
        private readonly dbContainer _db;

        public TaskRepo(dbContainer db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskMain>> GetAllAsync()
        {
            var Alltasks = _db.TaskMain.Select(a => a);
             return Alltasks;
        }

        public async Task<TaskMain> GetByIdAsync(int id)
        {
            var task = _db.TaskMain.FindAsync(id);
            return await task;
        }

        public async Task<TaskMain> AddObj(TaskMain obj)
        {
            var nnewObj = _db.TaskMain.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateObj(TaskMain obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TaskMain> DeleteObj(int id)
        {
            var taskDelete = _db.TaskMain.Find(id); 
            _db.TaskMain.Remove(taskDelete);
            return taskDelete;



        }
    }
}
