using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TaskDocuments
{
    public class TaskDocument_Repo:ITaskDocument_Repo
    {
        private readonly dbContainer _db;

        public TaskDocument_Repo(dbContainer db)
        {
            _db = db;
        }
        public  IEnumerable<TaskDocuments_tbl> GetAllAsync()
        {
            var data = _db.TaskDocuments_tbl.Select(a => a);
            return data;
        }

        public TaskDocuments_tbl GetByIdAsync(int id)
        {
            var data = _db.TaskDocuments_tbl.Find(id);
            return  data; 
        }

        public TaskDocuments_tbl AddObj(TaskDocuments_tbl obj)
        {
             _db.TaskDocuments_tbl.Add(obj); 
             _db.SaveChanges();
            return obj;
        }

        public async Task<TaskDocuments_tbl> UpdateObj(TaskDocuments_tbl obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TaskDocuments_tbl> DeleteObj(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
