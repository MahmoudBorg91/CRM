using System.Collections.Generic;

namespace GSI_Internal.Models.ViewModel
{
    public class ClientDashboardVM
    {
      
        
        public int RequsetToPayment_count { get; set; }
        public int RequestPaymentDone_count { get; set; }
        public int RequestUnderProcessing_count { get; set; }
        public int RequestDone_count { get; set; }
        public int RequestMissingInformation_count { get; set; }
        public int RequestMissingProcessing_count { get; set; }
       
        public int RequestRejectFromEntity_count { get; set; }
       
        public int RequestAll_count { get; set; }
        public IEnumerable<ApplicationTrans_RequestVM> ApplicationTrans_RequestVM { get; set; }
    }
}
