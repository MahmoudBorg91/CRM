using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.ApiRepositry.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbContainer _context;

        public IBaseRepository<ApplicationUser> Users { get; private set; }
        //public IBaseRepository<TransactionGroup> transactionGroup { get; private set; }
        //public IBaseRepository<TransactionItem> transactionItem { get; private set; }
        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }
        //public IBaseRepository<TransactionSubGroup> TransactionSubGroup { get; private set; }
        //public IBaseRepository<Requirements> Requirements { get; private set; }
        //public IBaseRepository<AssignRequirmentToItem> AssignRequirmentToItem { get; private set; }
        //public IBaseRepository<ApplicationTransaction_Request> ApplicationTransaction_Request { get; private set; }
        //public IBaseRepository<ApplicationTransaction_Request_Log> ApplicationTransaction_Request_Log { get; private set; }
        //public IBaseRepository<ApplicationTransfer> ApplicationTransfer { get; private set; }
        //public IBaseRepository<StatusTransfer_Name> StatusTransfer_Name { get; private set; }
        //public IBaseRepository<RequirmentsFileAttachment> RequirmentsFileAttachment { get; private set; }
        //public IBaseRepository<TransactionItemInquiry> TransactionItemInquiry { get; private set; }
        //public IBaseRepository<AssignInquiryToItem> AssignInquiryToItem { get; private set; }
        //public IBaseRepository<RequestInquiry_Answer> RequestInquiry_Answer { get; private set; }
        //public IBaseRepository<TransiactionItem_Selection> TransiactionItem_Selection { get; private set; }
        //public IBaseRepository<AssignSelectionToItem> AssignSelectionToItem { get; private set; }
        //public IBaseRepository<RequestSelection> RequestSelection { get; private set; }
        //public IBaseRepository<RequestSelection_Group> RequestSelection_Group { get; private set; }
        //public IBaseRepository<SlideShow> SlideShow { get; private set; }
        //public IBaseRepository<ApplicationTransaction_Request_Processing> ApplicationTransaction_Request_Processing { get; private set; }
        //public IBaseRepository<Notification> Notifications { get; private set; }
        //public IBaseRepository<NotificationConfirmed> NotificationsConfirmed { get; private set; }
        //public IBaseRepository<ContactUs> ContactUs { get; private set; }
        //public IBaseRepository<client_wallet> ClientWallet { get; private set; }
        //public IBaseRepository<TransactionItem_Type> TransactionItemType { get; private set; }


        public UnitOfWork(dbContainer context)
        {
            _context = context;
            Users = new BaseRepository<ApplicationUser>(_context);
            //transactionGroup = new BaseRepository<TransactionGroup>(_context);
            //transactionItem = new BaseRepository<TransactionItem>(_context);
            ApplicationUser = new BaseRepository<ApplicationUser>(_context);
            //TransactionSubGroup = new BaseRepository<TransactionSubGroup>(_context);
            //Requirements = new BaseRepository<Requirements>(_context);
            //AssignRequirmentToItem = new BaseRepository<AssignRequirmentToItem>(_context);
            //ApplicationTransaction_Request = new BaseRepository<ApplicationTransaction_Request>(_context);
            //ApplicationTransaction_Request_Log = new BaseRepository<ApplicationTransaction_Request_Log>(_context);
            //ApplicationTransfer = new BaseRepository<ApplicationTransfer>(_context);
            //StatusTransfer_Name = new BaseRepository<StatusTransfer_Name>(_context);
            //RequirmentsFileAttachment = new BaseRepository<RequirmentsFileAttachment>(_context);
            //TransactionItemInquiry = new BaseRepository<TransactionItemInquiry>(_context);
            //AssignInquiryToItem = new BaseRepository<AssignInquiryToItem>(_context);
            //RequestInquiry_Answer = new BaseRepository<RequestInquiry_Answer>(_context);
            //TransiactionItem_Selection = new BaseRepository<TransiactionItem_Selection>(_context);
            //AssignSelectionToItem = new BaseRepository<AssignSelectionToItem>(_context);
            //RequestSelection = new BaseRepository<RequestSelection>(_context);
            //RequestSelection_Group = new BaseRepository<RequestSelection_Group>(_context);
            //SlideShow = new BaseRepository<SlideShow>(_context);
            //ApplicationTransaction_Request_Processing = new BaseRepository<ApplicationTransaction_Request_Processing>(_context);
            //Notifications = new BaseRepository<Notification>(_context);
            //NotificationsConfirmed = new BaseRepository<NotificationConfirmed>(_context);
            //ContactUs = new BaseRepository<ContactUs>(_context);
            //ClientWallet = new BaseRepository<client_wallet>(_context);
            //TransactionItemType = new BaseRepository<TransactionItem_Type>(_context);




        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
