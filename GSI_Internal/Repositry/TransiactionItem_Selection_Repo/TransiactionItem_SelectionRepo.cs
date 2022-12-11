using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TransiactionItem_Selection_Repo
{
    public class TransiactionItem_SelectionRepo: ITransiactionItem_SelectionRepo
    {
        private readonly dbContainer db;
        public TransiactionItem_SelectionRepo(dbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<TransiactionItem_Selection> GetAll()
        {
            var data = db.TransiactionItem_Selection.Select(a => a);
            return data;
        }

        public TransiactionItem_Selection GetByID(int id)
        {
            var data = db.TransiactionItem_Selection.Find(id);
            return data;
        }

        public TransiactionItem_Selection AddObj(TransiactionItem_Selection obj)
        {
            var data = db.TransiactionItem_Selection.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public TransiactionItem_Selection UpdateObj(TransiactionItem_Selection obj)
        {
            var editdata = db.TransiactionItem_Selection.Find(obj.ID);
            editdata.SelectionName_Arabic = obj.SelectionName_Arabic;
            editdata.SelectionName_English = obj.SelectionName_English;
            editdata.SelectionGroupID=obj.SelectionGroupID;
            db.SaveChanges();
            return editdata;
        }

        public TransiactionItem_Selection DeleteObj(int id)
        {
           var data= db.TransiactionItem_Selection.Find(id);
           db.TransiactionItem_Selection.Remove(data);
           db.SaveChanges();
           return data;
        }
    }
}
