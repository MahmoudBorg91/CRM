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

        public TaskMain AddObj(TaskMain obj)
        {
            var nnewObj = _db.TaskMain.Add(obj);
             _db.SaveChanges();
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

        public async Task<TaskMain> UpdateTaskToUnderProcessing(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status=1;
            data.TransferFromUser=obj.TransferFromUser;
            data.TransferToUser=obj.TransferToUser;
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToReturn(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 2;
            data.TransferFromUser = obj.TransferFromUser;
            data.TransferToUser = obj.TransferToUser;
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToFinish(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 3;
            data.TransferFromUser = obj.TransferFromUser;
            data.TransferToUser = obj.TransferToUser;
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToArchive(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 4;
            data.TransferFromUser = obj.TransferFromUser;
            data.TransferToUser = obj.TransferToUser;
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}
