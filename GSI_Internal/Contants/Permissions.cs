using System;
using System.Collections.Generic;

namespace GSI_Internal.Contants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",



                $"Permissions.Tasks.OpenTaskManager",
                $"Permissions.Tasks.CreateTask",
                $"Permissions.Tasks.OpenTask",
                $"Permissions.Tasks.UnderProcessingTask",
                $"Permissions.Tasks.FinishTask",
                $"Permissions.Tasks.ArchiveTask",
                $"Permissions.Tasks.ReturnTask",
                $"Permissions.Tasks.DownloadArchive",


                $"Permissions.Request.RequestType_Manger",
                $"Permissions.Request.OpenRequest_Manger",
                $"Permissions.Request.AcceptRequest",
                $"Permissions.Request.RejectRequest",












              

              
               




            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static class Tasks
        {
            public const string View = "Permissions.Tasks.View";
            public const string Create = "Permissions.Tasks.Create";
            public const string Edit = "Permissions.Tasks.Edit";
            public const string Delete = "Permissions.Tasks.Delete";

            public const string OpenTaskManager = "Permissions.Tasks.OpenTaskManager";
            public const string CreateTask = "Permissions.Tasks.CreateTask";
            public const string OpenTask = "Permissions.Tasks.OpenTask";
            public const string UnderProcessingTask = "Permissions.Tasks.UnderProcessingTask";
            public const string FinishTask = "Permissions.Tasks.FinishTask";
            public const string ArchiveTask = "Permissions.Tasks.ArchiveTask";
            public const string ReturnTask = "Permissions.Tasks.ReturnTask";
            public const string DownloadArchive = "Permissions.Tasks.DownloadArchive";







        }

        public static class Request
        {
            public const string View = "Permissions.Request.View";
            public const string Create = "Permissions.Request.Create";
            public const string Edit = "Permissions.Request.Edit";
            public const string Delete = "Permissions.Request.Delete";

            public const string RequestType_Manger = "Permissions.Request.RequestData_Manger";
            public const string OpenRequest_Manger = "Permissions.Request.OpenRequest_Manger";
           
            public const string AcceptRequest = "Permissions.Request.AcceptRequest";
            public const string RejectRequest = "Permissions.Request.RejectRequest";

        }
        
        
        public static class Dashboard_Permissions
        {
            public const string View = "Permissions.Dashboard_Permissions.View";
            public const string Create = "Permissions.Dashboard_Permissions.Create";
            public const string Edit = "Permissions.Dashboard_Permissions.Edit";
            public const string Delete = "Permissions.Dashboard_Permissions.Delete";
           
           







        }



      




    }
}