using GSI_Internal.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GSI_Internal.Context
{
    public class dbContainer : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public dbContainer(DbContextOptions<dbContainer> ops) : base(ops)
        {

        }

        //public DbSet<Custamer> Custamers { get; set; }
        //public DbSet<Solution> Solutions { get; set; }
        //public DbSet<Applications> Applications { get; set; }
        //public DbSet<Lead> Lead { get; set; }
        //public DbSet<FollowUP> followUP { get; set; }
        //public DbSet<DemoRequestMain> DemoRequestMain { get; set; }
        //public DbSet<DemoRequestSub> DemoRequestSub { get; set; }
        public DbSet<TransactionGroup> transactionGroup { get; set; }
        public DbSet<TransactionItem> transactionItem { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TransactionSubGroup> TransactionSubGroup { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<AssignRequirmentToItem> AssignRequirmentToItem { get; set; }
        public DbSet<ApplicationTransaction_Request> ApplicationTransaction_Request { get; set; }
        public DbSet<ApplicationTransaction_Request_Log> ApplicationTransaction_Request_Log { get; set; }
        public DbSet<ApplicationTransfer> ApplicationTransfer { get; set; }
        public DbSet<StatusTransfer_Name> StatusTransfer_Name { get; set; }
        public DbSet<RequirmentsFileAttachment> RequirmentsFileAttachment { get; set; }
        public DbSet<TransactionItemInquiry> TransactionItemInquiry { get; set; }
        public DbSet<AssignInquiryToItem> AssignInquiryToItem { get; set; }

        public DbSet<RequestInquiry_Answer> RequestInquiry_Answer { get; set; }
        public DbSet<TransiactionItem_Selection> TransiactionItem_Selection { get; set; }
        public DbSet<AssignSelectionToItem> AssignSelectionToItem { get; set; }
        public DbSet<RequestSelection> RequestSelection { get; set; }
        public DbSet<RequestSelection_Group> RequestSelection_Group { get; set; }
        public DbSet<SlideShow> SlideShow { get; set; }
        public DbSet<ApplicationTransaction_Request_Processing> ApplicationTransaction_Request_Processing { get; set; }
        public DbSet<client_wallet> ClientWallet { get; set; }
        public  DbSet<Notification> Notifications { get; set; }
        public  DbSet<NotificationConfirmed> NotificationsConfirmed { get; set; }
     
        









    }
}
