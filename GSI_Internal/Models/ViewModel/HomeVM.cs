using System.Collections.Generic;
using GSI_Internal.Areas.Identity.Pages.Account;

namespace GSI_Internal.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<TransactionGroupVM> TransactionGroupVM { get; set; }
        public IEnumerable<TransactionItemVM> PopularTransactionItemVM { get; set; }
        public IEnumerable<TransactionItemVM> PopularTransactionItemVMINGroup { get; set; }

        public ApplicationTransaction_RequestVM applicationTransaction_RequestVM { get; set; }
        public IEnumerable<TransactionItemVM> TransactionItemVM { get; set; }

        public IEnumerable<TransactionSubGroupVM> TransactionSubGroupVM { get; set; }
        public IEnumerable<TransactionItemInfoVM> TransactionItemInfoVM { get; set; }
        public IEnumerable<SlideShowVM> SlideShowVM { get; set; }

        public IEnumerable<AssignRequirmentToItemVM> AssignRequirmentToItemVM { get; set; }

        public IEnumerable<AssignInquireytToItemVM> AssignInquireytToItemVM { get; set; }
        public IEnumerable<AssignSelectionToItemVM> AssignSelectionToItemVM { get; set; }
        
        public RegisterModel RegisterModel { get; set; }


        public OurCompanyInfo_VM OurCompanyInfo_VM { get; set; }
        public IEnumerable<OurPartnersAndOurCustomerVM> OurPartnersAndOurCustomerVM { get; set; }




    }
}
