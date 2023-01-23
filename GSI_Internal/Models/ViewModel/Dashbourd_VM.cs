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

        public int TaskToday { get; set; }
        public int Task1day { get; set; }
        public int Task2day { get; set; }
        public int Task3day { get; set; }
        public int Task4day { get; set; }
        public int Task5day { get; set; }
        public int Task6day { get; set; }

        public int RequestToday { get; set; }
        public int Request1day { get; set; }
        public int Request2day { get; set; }
        public int Request3day { get; set; }
        public int Request4day { get; set; }
        public int Request5day { get; set; }
        public int Request6day { get; set; }
    }
}
