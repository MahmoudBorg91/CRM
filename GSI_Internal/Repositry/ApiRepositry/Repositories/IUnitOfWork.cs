
using System;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Repositry.ApiRepositry.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ApplicationUser> Users { get; }
        /*  IBaseRepository<ApplicationRole> Roles { get; }*/

        //-----------------------------------------------------------------------------------
        IBaseRepository<TransactionGroup> transactionGroup { get; }
        IBaseRepository<TransactionItem> transactionItem { get; }

        IBaseRepository<ApplicationUser> ApplicationUser { get; }
        IBaseRepository<TransactionSubGroup> TransactionSubGroup { get; }
        IBaseRepository<Requirements> Requirements { get; }
        IBaseRepository<AssignRequirmentToItem> AssignRequirmentToItem { get; }
        IBaseRepository<ApplicationTransaction_Request> ApplicationTransaction_Request { get; }
        IBaseRepository<ApplicationTransaction_Request_Log> ApplicationTransaction_Request_Log { get; }
        IBaseRepository<ApplicationTransfer> ApplicationTransfer { get; }
        IBaseRepository<StatusTransfer_Name> StatusTransfer_Name { get; }
        IBaseRepository<RequirmentsFileAttachment> RequirmentsFileAttachment { get; }
        IBaseRepository<TransactionItemInquiry> TransactionItemInquiry { get; }
        IBaseRepository<AssignInquiryToItem> AssignInquiryToItem { get; }

        IBaseRepository<RequestInquiry_Answer> RequestInquiry_Answer { get; }
        IBaseRepository<TransiactionItem_Selection> TransiactionItem_Selection { get; }
        IBaseRepository<AssignSelectionToItem> AssignSelectionToItem { get; }
        IBaseRepository<RequestSelection> RequestSelection { get; }
        IBaseRepository<RequestSelection_Group> RequestSelection_Group { get; }
        IBaseRepository<SlideShow> SlideShow { get; }
        IBaseRepository<ApplicationTransaction_Request_Processing> ApplicationTransaction_Request_Processing { get; }

        IBaseRepository<Notification> Notifications { get; }
        IBaseRepository<NotificationConfirmed> NotificationsConfirmed { get; }

        //-----------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
