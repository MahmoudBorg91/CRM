using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GSI_Internal.Repositry.Client_WalletRepo
{
    public class ClientWalletRepo : IClientWalletRepo
    {
        private readonly dbContainer db;

        public ClientWalletRepo(dbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<client_wallet> GetAll()
        {
            var data = db.ClientWallet.Select(a => a);
            return data;
        }

        public client_wallet GetByID(int id)
        {
            var data = db.ClientWallet.Find(id);
            return data;
        }

        public client_wallet AddObj(client_wallet obj)
        {
           var data = db.ClientWallet.Add(obj);
           db.SaveChanges();
           return obj;
        }

        public client_wallet UpdateObj(client_wallet obj)
        {
            var updatedate = db.ClientWallet.Find(obj.Id);
            updatedate.FileName = obj.FileName;
            updatedate.UserId=obj.UserId;
            updatedate.RequireID = obj.RequireID;
            updatedate.TheDateFile = obj.TheDateFile;
            db.SaveChanges();
            return obj;
        }

        public client_wallet DeleteObj(int id)
        {
           var removedata = db.ClientWallet.Find(id);
           db.ClientWallet.Remove(removedata);
           db.SaveChanges();
           return removedata;
        }
    }
}
