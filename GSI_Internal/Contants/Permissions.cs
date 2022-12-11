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
                
                $"Permissions.Dashboard_Permissions.GetAppLicationToReview",
                $"Permissions.Dashboard_Permissions.GetAppLicationByStatus",
                $"Permissions.Dashboard_Permissions.GetAllAppLication",
                $"Permissions.Dashboard_Permissions.UpdateRequestToSubmation",
                $"Permissions.Dashboard_Permissions.UpdateRequestToPayment",
                $"Permissions.Dashboard_Permissions.UpdateRequestToPaymentDone",
                $"Permissions.Dashboard_Permissions.UpdateRequestUnderProcessing",
                $"Permissions.Dashboard_Permissions.UpdateRequestToDone",
                $"Permissions.Dashboard_Permissions.UpdateRequestToMissingInformation",
                $"Permissions.Dashboard_Permissions.UpdateRequestToMissingProcessing",
                $"Permissions.Dashboard_Permissions.UpdateRequestRejectFromUS",
                $"Permissions.Dashboard_Permissions.UpdateRequestRejectFromEntity",
                $"Permissions.Dashboard_Permissions.GetAllSubservicesInfo",

              
               




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

        public static class SubServicesInquiry
        {
            public const string View = "Permissions.SubServicesInquiry.View";
            public const string Create = "Permissions.SubServicesInquiry.Create";
            public const string Edit = "Permissions.SubServicesInquiry.Edit";
            public const string Delete = "Permissions.SubServicesInquiry.Delete";
        }

        public static class Enitiy
        {
            public const string View = "Permissions.Enitiy.View";
            public const string Create = "Permissions.Enitiy.Create";
            public const string Edit = "Permissions.Enitiy.Edit";
            public const string Delete = "Permissions.Enitiy.Delete";
        }
        public static class Main_Services
        {
            public const string View = "Permissions.Main_Services.View";
            public const string Create = "Permissions.Main_Services.Create";
            public const string Edit = "Permissions.Main_Services.Edit";
            public const string Delete = "Permissions.Main_Services.Delete";
        }
        public static class Sub_Services
        {
            public const string View = "Permissions.Sub_Services.View";
            public const string Create = "Permissions.Sub_Services.Create";
            public const string Edit = "Permissions.Sub_Services.Edit";
            public const string Delete = "Permissions.Sub_Services.Delete";
        }
        public static class Requirements
        {
            public const string View = "Permissions.Requirements.View";
            public const string Create = "Permissions.Requirements.Create";
            public const string Edit = "Permissions.Requirements.Edit";
            public const string Delete = "Permissions.Requirements.Delete";
        }
    
        public static class AssignRequirmentToItem
        {
            public const string View = "Permissions.AssignRequirmentToItem.View";
            public const string Create = "Permissions.AssignRequirmentToItem.Create";
            public const string Edit = "Permissions.AssignRequirmentToItem.Edit";
            public const string Delete = "Permissions.AssignRequirmentToItem.Delete";
        }
        public static class Dashboard_Permissions
        {
            public const string View = "Permissions.Dashboard_Permissions.View";
            public const string Create = "Permissions.Dashboard_Permissions.Create";
            public const string Edit = "Permissions.Dashboard_Permissions.Edit";
            public const string Delete = "Permissions.Dashboard_Permissions.Delete";
            public const string GetAppLicationToReview = "Permissions.Dashboard_Permissions.GetAppLicationToReview";
            public const string GetAppLicationByStatus = "Permissions.Dashboard_Permissions.GetAppLicationByStatus";
            public const string GetAllAppLication = "Permissions.Dashboard_Permissions.GetAllAppLication";
            public const string UpdateRequestToSubmation = "Permissions.Dashboard_Permissions.UpdateRequestToSubmation";
            public const string UpdateRequestToPayment = "Permissions.Dashboard_Permissions.UpdateRequestToPayment";
            public const string UpdateRequestToPaymentDone = "Permissions.Dashboard_Permissions.UpdateRequestToPaymentDone";
            public const string UpdateRequestUnderProcessing = "Permissions.Dashboard_Permissions.UpdateRequestUnderProcessing";
            public const string UpdateRequestToDone = "Permissions.Dashboard_Permissions.UpdateRequestToDone";
            public const string UpdateRequestToMissingInformation = "Permissions.Dashboard_Permissions.UpdateRequestToMissingInformation";
            public const string UpdateRequestToMissingProcessing = "Permissions.Dashboard_Permissions.UpdateRequestToMissingProcessing";
            public const string UpdateRequestRejectFromUS = "Permissions.Dashboard_Permissions.UpdateRequestRejectFromUS";
            public const string UpdateRequestRejectFromEntity = "Permissions.Dashboard_Permissions.UpdateRequestRejectFromEntity";
            public const string GetAllSubservicesInfo = "Permissions.Dashboard_Permissions.GetAllSubservicesInfo";







        }



      




    }
}