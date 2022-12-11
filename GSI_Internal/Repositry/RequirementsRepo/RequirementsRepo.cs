using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;
namespace GSI_Internal.Repositry.RequirementsRepo
{
    public class RequirementsRepo : IRequirementsRepo
    {
        private readonly dbContainer db;

        public RequirementsRepo(dbContainer db)
        {
            this.db = db;
        }
        public Requirements AddObj(Requirements obj)
        {
            db.Requirements.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Requirements DeleteObj(int id)
        {
            var data = db.Requirements.Find(id);
            db.Remove(data);
            db.SaveChanges();
            return data;
        }

        public IEnumerable<Requirements> GetAll()
        {
            var data = db.Requirements.Select(a => a);
            return data;
        }

        public Requirements GetByID(int id)
        {
            var data = db.Requirements.Find(id);
            return data;
        }

        public Requirements UpdateObj(Requirements obj)
        {
            var updateDate = db.Requirements.Find(obj.ID);

            updateDate.RequirementName_Arabic = obj.RequirementName_Arabic;
            updateDate.RequirementName_English = obj.RequirementName_English;
            db.SaveChanges();
            return obj;
        }
    }
}
