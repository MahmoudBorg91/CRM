using GSI_Internal.Entites;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GSI_Internal.Repositry.Client_WalletRepo
{
    public interface IClientWalletRepo
    {
        IEnumerable<client_wallet> GetAll();
        client_wallet GetByID(int id);

        client_wallet AddObj(client_wallet obj);
        client_wallet UpdateObj(client_wallet obj);
        client_wallet DeleteObj(int id);
    }
}
