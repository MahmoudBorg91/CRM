using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Repositry.TaskRepo
{
    public class TaskRepo : ITaskRepo
    {
        private readonly dbContainer _db;

        public TaskRepo(dbContainer db)
        {
            _db = db;
        }

        public IEnumerable<TaskMain> GetAllAsync()
        {
            var Alltasks = _db.TaskMain.Select(a => a);
             return Alltasks;
        }

        public  TaskMain GetByIdAsync(int id)
        {
            var task = _db.TaskMain.Find(id);
            return  task;
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
           
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToReturn(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 2;
            data.TransferFromUser=obj.TransferFromUser;
            data.TransferToUser = obj.TransferToUser;
           
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToFinish(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 3;
            
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskMain> UpdateTaskToArchive(TaskMain obj)
        {
            var data = _db.TaskMain.Find(obj.Id);
            data.Status = 4;
           
            await _db.SaveChangesAsync();
            return obj;
        }

        public string GetStatusName(int StatusID)
        {
            var data = _db.TaskStatusName.Where(a => a.StatusAction_Code == StatusID).Select(a => a.StatusName).FirstOrDefault();
            return data;
        }

        public string GetPriorityName(int StatusID)
        {
            var data = _db.TaskPriorityLevel.Where(a => a.PriorityLevel_ID == StatusID).Select(a => a.PriorityLevel_Name).FirstOrDefault();
            return data;
        }
    }
}
