using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models;

public class TaskMain_VM
{
    public int ID { get; set; }
    public string TaskName{ get; set; }
    public string TaskNote { get; set; }
    public DateTime DateOFReceving { get; set; }
    public DateTime DateOfCreating { get; set; }
    public DateTime DueDateOfEndTask { get; set; }
    //public string WhoSentIt { get; set; }
    public string UserCreate { get; set; }
    public string UserCreate_Name { get; set; }
    public int  Status { get; set; }
    public int PriorityLevel { get; set; }
    public string TransferFromUser  { get; set; }
    public string TransferFromUser_Name { get; set; }
    public string TransferToUser { get; set; }
    public string TransferToUser_Name { get; set; }
    public List<IFormFile> DocIform  { get; set; }
    public virtual ICollection<TaskDocuments_VM> TaskDocumentsVm { get; set; }
}