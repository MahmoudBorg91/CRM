namespace GSI_Internal.Models.ViewModel
{
    public class Dashbourd_VM
    {
        public int NumberOfAllTasks { get; set; }
        public int NumberOfNewTask { get; set; }
        public int NumberOfUnderProcessing { get; set; }
        public int NumberOfReturnProcessing { get; set; }
        public int NumberOfUnderFinish{ get; set; }
        public int NumberOfArchiveRequest { get; set; }
        public int NewRequest { get; set; }
        public int RequestAccect { get; set; }
        public int RequestRegect { get; set; }
        public int  AllRequest { get; set; }
    }
}
