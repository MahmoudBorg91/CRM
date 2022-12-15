using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.Application_Status_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.DashboardRepo;
using GSI_Internal.Repositry.RequestInquiry_AnswerRepo;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using GSI_Internal.Repositry.RequestSelection_SelectedRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;


namespace GSI_Internal.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ClientDashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApplicationTransaction_RequestRepo applicationTransactionRequestRepo;
        private readonly IApplication_StatusRepo applicationStatusRepo;
        private readonly IApplication_StatusRepo application_StatusRepo;
        private readonly IDashboardRepo dashboardRepo;
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly IAssignRequirmentToItemRepo _assignRequirmentToItemRepo;
        private readonly IRequestInquiry_AnswerRpo _inquiryAnswerRpo;
        private readonly ITransiactionItem_SelectionRepo _itemSelectionRepo;
        private readonly ITransactionItemInquiryReop _transactionItemInquiryRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;
        private readonly IRequestSelection_Selectes _requestSelectionSelectes;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly IAssignInquireytToItemRepo assignInquireytToItemRepo;
        private readonly IAssignSelectionToItemRepo assignSelectionToItemRepo;
        private readonly IRequestSelection_GroupRepo selectionGroupRepo;
        private readonly IHubContext<SignalrServer> signalrHub;
        private readonly IApplicationTransaction_Request_LogRepo applicationTransactionRequestLogRepo;
        private readonly dbContainer db;

        public ClientDashboardController(UserManager<ApplicationUser> userManager, IApplicationTransaction_RequestRepo applicationTransaction_RequestRepo,
            IApplication_StatusRepo application_StatusRepo, IDashboardRepo dashboardRepo, ITransactionItemRepo transactionItemRepo,
            IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo,
            IRequirementsRepo requirementsRepo,IAssignRequirmentToItemRepo assignRequirmentToItemRepo,
            IRequestInquiry_AnswerRpo inquiryAnswerRpo, ITransiactionItem_SelectionRepo itemSelectionRepo,
            ITransactionItemInquiryReop transactionItemInquiryRepo ,ITransactionGroupRepo transactionGroupRepo ,
            IRequestSelection_Selectes requestSelectionSelectes,ITransactionSubGroupRepo transactionSubGroupRepo , IAssignInquireytToItemRepo assignInquireytToItemRepo ,
            IAssignSelectionToItemRepo assignSelectionToItemRepo, IRequestSelection_GroupRepo selectionGroupRepo, IHubContext<SignalrServer> signalrHub,
            IApplicationTransaction_Request_LogRepo applicationTransaction_Request_LogRepo, dbContainer db

            )
        {
            this.userManager = userManager;
            applicationTransactionRequestRepo = applicationTransaction_RequestRepo;
            applicationStatusRepo = application_StatusRepo;
            this.application_StatusRepo = application_StatusRepo;
            this.dashboardRepo = dashboardRepo;
            this.transactionItemRepo = transactionItemRepo;
            this.requirmentsFileAttachmentRepo = requirmentsFileAttachmentRepo;
            this.requirementsRepo = requirementsRepo;
            _assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            _inquiryAnswerRpo = inquiryAnswerRpo;
            _itemSelectionRepo = itemSelectionRepo;
            _transactionItemInquiryRepo = transactionItemInquiryRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            _requestSelectionSelectes = requestSelectionSelectes;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.assignInquireytToItemRepo = assignInquireytToItemRepo;
            this.assignSelectionToItemRepo = assignSelectionToItemRepo;
            this.selectionGroupRepo = selectionGroupRepo;
            this.signalrHub = signalrHub;
            applicationTransactionRequestLogRepo = applicationTransaction_Request_LogRepo;
            this.db = db;
        }
        public IActionResult Index()
        {
            ClientDashboardVM clientDashboardVm = new ClientDashboardVM();
            clientDashboardVm.RequestAll_count =
                applicationTransactionRequestRepo.GetAll().Count(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier));
            clientDashboardVm.RequestUnderProcessing_count =
                applicationTransactionRequestRepo.GetAll().Count(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status is 0 or 1 or 10 );
           
            
            
            clientDashboardVm.RequsetToPayment_count =
                applicationTransactionRequestRepo.GetAll().Count(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status is 2 );
           
            clientDashboardVm.RequestMissingInformation_count =
                applicationTransactionRequestRepo.GetAll().Count(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status is 6 or 7 );
        clientDashboardVm.ApplicationTrans_RequestVM= dashboardRepo.GetAllTransactioc().Where(a=>a.ClientID== User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => new ApplicationTrans_RequestVM
        {
            ID = a.ID,
            ClientName = a.ClientName,
            ClientPhone = a.ClientPhone,
            UserEmail = a.UserEmail,
            The_Date = a.The_Date,
            TransiactionItem_Code = a.TransiactionItem_Code,
            TransiactionItem_Name = a.TransiactionItem_Name,
            TransiactionItem_NameEnglish = transactionItemRepo.GetAll().Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish).FirstOrDefault(),
            TransiactionItem_Price = a.TransiactionItem_Price,
            TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
            TransiactionItem_Net = a.TransiactionItem_Net,
            Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status),

            NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity
           }).OrderByDescending(a=>a.The_Date).ToList();
            return View(clientDashboardVm);
        }

        public IActionResult MyDocments()
        {
            var Data = requirmentsFileAttachmentRepo.GetAll()
                .Where(a => a.UserID == User.FindFirstValue(ClaimTypes.NameIdentifier)).
                
                
                
                
                Select(a =>
                    new RequirmentsFileAttachmentVM()
                    {
                        RequireID = a.RequireID,
                        RequireName_Arabic = requirementsRepo.GetAll().Where(r=>r.ID==a.RequireID).Select(a=>a.RequirementName_Arabic).FirstOrDefault(),
                        RequireName_English = requirementsRepo.GetAll().Where(r => r.ID == a.RequireID).Select(a => a.RequirementName_English).FirstOrDefault()
                      
                        
                    }).GroupBy(f=> new {f.RequireID,f.RequireName_Arabic,f.RequireName_English }).Select(g=> new RequirmentsFileAttachmentVM()
                {
                    

                    RequireID= g.Key.RequireID,
                    RequireName_Arabic= g.Key.RequireName_Arabic,
                    RequireName_English=  g.Key.RequireName_English
                }).ToList();
            return View(Data);
        }
        public FileResult DownloadFileRequirmentApplication(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }
        public IActionResult SelectClientDocument(int ID)
        {
            var data = requirmentsFileAttachmentRepo.GetAll().Where(a =>
                    a.UserID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.RequireID == ID)
                .Select(r => new RequirmentsFileAttachmentVM()
                {
                    Id = r.Id,
                    App_Code = r.App_Code,
                    RequireID = r.RequireID,
                    RequireName_Arabic = requirementsRepo.GetAll().Where(s => s.ID == r.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                    RequireName_English = requirementsRepo.GetAll().Where(s => s.ID == r.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                    FileName = r.FileName,
                    AppDateTime = applicationTransactionRequestRepo.GetAll().Where(a=>a.ID==r.App_Code).Select(a=>a.The_Date).FirstOrDefault(),
                  


                }).OrderByDescending(o => o.AppDateTime).ToList();

            return View(data);
        }

        public IActionResult ChangeOrUploudFileAttachMend(int id)
        {

            var data = requirmentsFileAttachmentRepo.GetAll().Where(a => a.Id == id && a.UserID== User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(r =>
                new RequirmentsFileAttachmentVM()
                {
                    Id = r.Id,
                    RequireID = r.RequireID,
                    RequireName_Arabic = requirementsRepo.GetAll().Where(c => c.ID == r.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                    RequireName_English = requirementsRepo.GetAll().Where(c => c.ID == r.RequireID).Select(a => a.RequirementName_English).FirstOrDefault()

                }).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult ChangeOrUploudFileAttachMend(RequirmentsFileAttachmentVM obj)
        {

            RequirmentsFileAttachment neAttachment = new RequirmentsFileAttachment();
            if (obj.FileName_FormFIle != null)
            {
                string UploadFilesPhotPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";
                string UploadFilesfilename = (requirementsRepo.GetAll().Where(a => a.ID == obj.RequireID).Select(a => a.RequirementName_English).FirstOrDefault() + Guid.NewGuid() + System.IO.Path.GetExtension(obj.FileName_FormFIle.FileName));
                obj.FileName_FormFIle.CopyTo(new System.IO.FileStream(UploadFilesPhotPath + UploadFilesfilename, System.IO.FileMode.Create));
               neAttachment.Id=obj.Id;
                neAttachment.FileName = UploadFilesfilename;
                requirmentsFileAttachmentRepo.EditFile(neAttachment);
            }

           
            return RedirectToAction("SelectClientDocument",obj.RequireID);
        }


        [Route("/ClientDashboard/GetAppLicationByStatus/{status}")]
        public Task<IActionResult> GetAppLicationByStatus(int status)
        {
            //Response.Headers.Add("Refresh", "5");

            switch (status)
            {
                case 0 or 1 or 10:
                {
                    var data1 = dashboardRepo.GetAllTransactioc()
                        .Where(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
                                    a.Status is 0 or 1 or 10).Select(a => new ApplicationTrans_RequestVM
                        {
                            ID = a.ID,
                            ClientName = a.ClientName,
                            ClientPhone = a.ClientPhone,
                            UserEmail = a.UserEmail,
                            The_Date = a.The_Date,
                            Country_Name = a.Country_Name,
                            TransiactionItem_Code = a.TransiactionItem_Code,
                            TransiactionItem_Name = a.TransiactionItem_Name,
                            TransiactionItem_NameEnglish = transactionItemRepo.GetAll()
                                .Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish)
                                .FirstOrDefault(),
                            TransiactionItem_Price = a.TransiactionItem_Price,
                            TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                            TransiactionItem_Net = a.TransiactionItem_Net,
                            NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                            Status = a.Status,
                            Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status)
                                    }).OrderByDescending(a => a.The_Date).ToList();

                    return Task.FromResult<IActionResult>(View(data1));
                }
                case 2:
                {
                    var data2 = dashboardRepo.GetAllTransactioc()
                        .Where(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status is 2).Select(
                            a => new ApplicationTrans_RequestVM
                            {
                                ID = a.ID,
                                ClientName = a.ClientName,
                                ClientPhone = a.ClientPhone,
                                UserEmail = a.UserEmail,
                                The_Date = a.The_Date,
                                Country_Name = a.Country_Name,
                                TransiactionItem_Code = a.TransiactionItem_Code,
                                TransiactionItem_Name = a.TransiactionItem_Name,
                                TransiactionItem_NameEnglish = transactionItemRepo.GetAll()
                                    .Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish)
                                    .FirstOrDefault(),
                                TransiactionItem_Price = a.TransiactionItem_Price,
                                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                                TransiactionItem_Net = a.TransiactionItem_Net,
                                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                                Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status),
                                Status = a.Status
                            }).OrderByDescending(a => a.The_Date).ToList();

                    return Task.FromResult<IActionResult>(View(data2));
                }
                case 6 or 7:
                {
                    var data3 = dashboardRepo.GetAllTransactioc()
                        .Where(a => a.ClientID == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status is 6 or 7).Select(
                            a => new ApplicationTrans_RequestVM
                            {
                                ID = a.ID,
                                ClientName = a.ClientName,
                                ClientPhone = a.ClientPhone,
                                UserEmail = a.UserEmail,
                                The_Date = a.The_Date,
                                Country_Name = a.Country_Name,
                                TransiactionItem_Code = a.TransiactionItem_Code,
                                TransiactionItem_Name = a.TransiactionItem_Name,
                                TransiactionItem_NameEnglish = transactionItemRepo.GetAll()
                                    .Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish)
                                    .FirstOrDefault(),
                                TransiactionItem_Price = a.TransiactionItem_Price,
                                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                                TransiactionItem_Net = a.TransiactionItem_Net,
                                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                                Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status),
                                Status = a.Status
                            }).OrderByDescending(a => a.The_Date).ToList();

                    return Task.FromResult<IActionResult>(View(data3));
                }
                default:
                    return Task.FromResult<IActionResult>(View());
            }
        }
        [HttpGet]
        [Route("/ClientDashboard/GetAppLicationToReview/{ID}")]
        public Task<IActionResult> GetAppLicationToReview(Guid ID)
        {




        
            var data = dashboardRepo.GetByAPPCode(ID);
            ApplicationTrans_RequestVM obj = new ApplicationTrans_RequestVM()
            { 
                
                ID = data.ID,
            ClientName = data.ClientName,
            ClientPhone = data.ClientPhone,
            ServicesPhoto = transactionItemRepo.GetByID(data.TransiactionItem_Code).ServicesPhoto,
            TransactionItemVM = transactionItemRepo.GetAll().Where(c => c.ID == data.TransiactionItem_Code).Select(
                a => new TransactionItemVM
                {
                    Time_Services_Arabic = a.Time_Services_Arabic,
                    Time_Services_English = a.Time_Services_English,
                    ServicesPhoto = a.ServicesPhoto,
                    TransactionGroupName = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID)
                        .Select(m => m.TransactionGroup_NameArabic).FirstOrDefault(),
                    TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID)
                        .Select(m => m.TransactionGroup_NameEnglish).FirstOrDefault(),
                    TransactionSubGroupName = transactionSubGroupRepo.GetAll()
                        .Where(x => x.ID == a.TransactionSubGroupID)
                        .Select(x => x.SubGroupNameArabic).FirstOrDefault(),
                    TransactionSubGroupNameEnglish = transactionSubGroupRepo.GetAll()
                        .Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameEnglish)
                        .FirstOrDefault(),
                    Services_Conditions_English = a.Services_Conditions_English,
                    Services_Conditions_Arabic = a.Services_Conditions_Arabic,

                }).ToList(),
            UserEmail = data.UserEmail,
            The_Date = data.The_Date,
            TransiactionItem_Code = data.TransiactionItem_Code,
            TransiactionItem_Name = data.TransiactionItem_Name,
            TransiactionItem_Price = data.TransiactionItem_Price,
            TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees,
            TransiactionItem_Net = data.TransiactionItem_Net,
            ClientNotes = data.ClientNotes,
            files = data.files,
            Status = data.Status,
            StatusName = application_StatusRepo.GetStatusTransfer_Name(data.Status),
            NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity,
            AssignRequirmentToItemVM = _assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
            {
                RequirmentID = m.ID,

                Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

            }).ToList(),



            RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == ID).Select(c => new RequirmentsFileAttachmentVM()
            {
                RequireID = c.RequireID,
                RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                FileName = c.FileName
            }).ToList(),
            RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == ID).Select(w =>
                new RequestInquiry_Answer_VM()
                {

                    InquiryID = w.InquiryID,
                    InquiryName_Arabic = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == w.InquiryID)
                        .Select(c => c.InquiryName_Arabic).FirstOrDefault(),
                    InquiryName_English = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == w.InquiryID)
                        .Select(c => c.InquiryName_English).FirstOrDefault(),
                    Inquiry_Type = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == w.InquiryID)
                        .Select(c => c.Inquiry_Type).FirstOrDefault(),
                    Inquiry_Answer = w.Inquiry_Answer
                }).ToList(),
            RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == ID && n.IsSelected == true).Select(
                m => new RequestSelectionVM()
                {

                    SelectionID = m.SelectionID,
                    SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                    SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_English).FirstOrDefault(),
                    IsSelected = m.IsSelected

                }).ToList()
        };
        


          
            //BackgroundJob.Schedule(() => EndSessision(), TimeSpan.FromMinutes(1));
         
            return Task.FromResult<IActionResult>(View(obj));



        }


        public FileResult DownloadFile(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }

        [HttpPost]
        public async Task<IActionResult> UpdateObjToPaymentDone(ApplicationTrans_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransactionRequestRepo.UpdateObjToPaymentDone(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 3;

            await applicationTransactionRequestLogRepo.AddObj(addlog);
            await signalrHub.Clients.All.SendAsync("loadRequests");
          





            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateObjToMissingDone(ApplicationTrans_RequestVM obj)
        {

            ApplicationTransaction_Request newobj = new ApplicationTransaction_Request();
            if (ModelState.IsValid)
            {
                Thread.Sleep(3000);


                if (obj.files_Upload != null)
                {
                    string UploadFilesPhotPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";
                    string UploadFilesfilename = Guid.NewGuid() + System.IO.Path.GetFileName(obj.files_Upload.FileName);
                    obj.files_Upload.CopyTo(new System.IO.FileStream(UploadFilesPhotPath + UploadFilesfilename, System.IO.FileMode.Create));
                    newobj.files = UploadFilesfilename;

                }




                //obj.ApplicationTransaction_RequestVM = JsonSerializer.Serialize(ApplicationTransaction_Request);


                //  obj.ApplicationTrans_RequestVM = JsonConvert.DeserializeObject<ApplicationTrans_RequestVM>(obj.ApplicationTrans_RequestVM);


                newobj.TransiactionItem_Code = obj.TransiactionItem_Code;
                newobj.TransiactionItem_Name = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.TransactionNameArabic).FirstOrDefault();
                newobj.TransiactionItem_Price = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.Price).FirstOrDefault();
                newobj.TransiactionItem_GovernmentFees = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.GovernmentFees).FirstOrDefault();
                newobj.TransiactionItem_Net = newobj.TransiactionItem_Price + newobj.TransiactionItem_GovernmentFees;
                newobj.ClientID = userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newobj.ClientName = userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.FirstName)
                    .FirstOrDefault();
                newobj.ClientPhone = userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.PhoneNumber)
                    .FirstOrDefault();

                newobj.ClientLastName = userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.LastName)
                    .FirstOrDefault();

                newobj.Country_Name = " ";
                newobj.UserEmail = userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Email)
                    .FirstOrDefault();

                newobj.The_Date = DateTime.Now;
                newobj.Move_Type = 1;
                newobj.Status = 11;
                newobj.NumberOfTransiactionOfEntity = "0";
                newobj.TarnferUserFrom = obj.Status.ToString();
                newobj.TransferUserTo = "11";
                newobj.ClientNotes = obj.ClientNotes;
                newobj.IsProsessByUser = 0;
                newobj.UserProsessID = "";

                if (obj.RequirmentsFileAttachmentVM != null)
                {

                    foreach (var ApplicationFile in obj.RequirmentsFileAttachmentVM)
                    {

                        RequirmentsFileAttachment newattachment = new RequirmentsFileAttachment();
                        if (ApplicationFile.FileHistoryNameSave != "0")
                        {
                            newattachment.FileName = ApplicationFile.FileHistoryNameSave;
                        }
                        else
                        {
                            if (ApplicationFile.FileName_FormFIle != null)
                            {
                                string uploadFilesAttachPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";
                                string uploadFilesAttachename = (requirementsRepo.GetAll().Where(a => a.ID == ApplicationFile.RequireID).Select(a => a.RequirementName_English).FirstOrDefault() + Guid.NewGuid().ToString() + "_" + System.IO.Path.GetExtension(ApplicationFile.FileName_FormFIle.FileName));

                                await using (var fileStream = new FileStream(Path.Combine(uploadFilesAttachPath, uploadFilesAttachename), FileMode.Create))
                                {
                                    await ApplicationFile.FileName_FormFIle.CopyToAsync(fileStream);
                                }


                                newattachment.FileName = uploadFilesAttachename;
                            }
                        }





                        newattachment.UserID = userManager.Users
                            .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                            .FirstOrDefault();
                        newattachment.RequireID = ApplicationFile.RequireID;


                        newobj.RequirmentsFileAttachments.Add(newattachment);

                    }
                }


                if (obj.RequestInquiry_Answer_VM != null)
                {
                    foreach (var ApplicationAnswer in obj.RequestInquiry_Answer_VM)
                    {
                        RequestInquiry_Answer appAnswer = new RequestInquiry_Answer();
                        appAnswer.InquiryID = ApplicationAnswer.InquiryID;
                        appAnswer.Inquiry_Answer = ApplicationAnswer.Inquiry_Answer;
                        newobj.RequestInquiry_Answer.Add(appAnswer);
                    }
                }

                if (obj.RequestSelectionVM != null)
                {
                    foreach (var Selection in obj.RequestSelectionVM)
                    {
                        RequestSelection appSelection = new RequestSelection();
                        appSelection.SelectionID = Selection.SelectionID;
                        appSelection.IsSelected = Selection.IsSelected;
                        newobj.RequestSelection.Add(appSelection);
                    }
                }



                applicationTransactionRequestRepo.EditObj(newobj);
                FinishApplicationVM FinishApplicationVM = new FinishApplicationVM();
                FinishApplicationVM.App_ID = newobj.ID;
                FinishApplicationVM.ClientName = newobj.ClientName;
                FinishApplicationVM.ClientLastName = newobj.ClientLastName;
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");
            }



        }

    }
}
