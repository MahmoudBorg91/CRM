using System;

namespace GSI_Internal.Entites
{
    public class TaskMain
    {
        public int ID { get; set; }
        public string TaskName{ get; set; }
        public string TaskNote { get; set; }
        public DateTime DateOFReceving { get; set; }
        public DateTime DateOfCreating { get; set; }
        public DateTime DueDateOfEndTask { get; set; }
        //public string WhoSentIt { get; set; }
        public string UserCreate { get; set; }
        public int  Status { get; set; }
        public int PriorityLevel { get; set; }
        public string TransferFromUser  { get; set; }
        public string TransferToUser { get; set; }
       
        


        


    }
}
