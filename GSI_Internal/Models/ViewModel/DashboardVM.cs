using System.Collections.Generic;

namespace GSI_Internal.Models.ViewModel
{
    public class DashboardVM
    {
        public int NewRequest_count { get; set; }
        public int RequestSubmation_count { get; set; }
        public int RequsetToPayment_count { get; set; }
        public int RequestPaymentDone_count { get; set; }
        public int RequestUnderProcessing_count { get; set; }
        public int RequestDone_count { get; set; }
        public int RequestMissingInformation_count { get; set; }
        public int RequestMissingProcessing_count { get; set; }
        public int RequestRejectFromUS_count { get; set; }
        public int RequestRejectFromEntity_count { get; set; }
        public int RequestTransferAllUser { get; set; }
        public int RequestTransferOneUser { get; set; }
        public int RequestAll_count { get; set; }

        public IEnumerable<NewTransactionRequestViewModel> NewTransactionRequestViewModel { get; set; }



    }
}
