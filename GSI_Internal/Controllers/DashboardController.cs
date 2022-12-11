using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.Application_Status_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.ApplicationTransferRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.DashboardRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.RequestInquiry_AnswerRepo;
using GSI_Internal.Repositry.RequestSelection_SelectedRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Hangfire;
using Microsoft.AspNetCore.SignalR;

namespace GSI_Internal.Controllers
{
 
    public class DashboardController : Controller
    {
        private readonly IApplicationTransaction_RequestRepo applicationTransaction_RequestRepo;
        private readonly IApplication_StatusRepo application_StatusRepo;
        private readonly IAppliactionTransferRepo appliactionTransferRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly IApplicationTransaction_Request_LogRepo applicationTransaction_Request_LogRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly IDashboardRepo dashboardRepo;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAssignInquireytToItemRepo _assignInquireytToItemRepo;
        private readonly ITransactionItemInquiryReop _transactionItemInquiryRepo;
        private readonly IRequestInquiry_AnswerRpo _inquiryAnswerRpo;
        private readonly ITransiactionItem_SelectionRepo _itemSelectionRepo;
        private readonly IAssignSelectionToItemRepo _assignSelectionToItemRepo;
        private readonly IRequestSelection_Selectes _requestSelectionSelectes;
        private readonly IHubContext<SignalrServer> _signalrHub;
        public DashboardController(UserManager<ApplicationUser> userManager,IApplicationTransaction_RequestRepo applicationTransaction_RequestRepo, 
            IApplication_StatusRepo application_StatusRepo , IAppliactionTransferRepo appliactionTransferRepo , 
            ITransactionGroupRepo transactionGroupRepo, ITransactionSubGroupRepo transactionSubGroupRepo, 
            IApplicationTransaction_Request_LogRepo applicationTransaction_Request_LogRepo, IRequirementsRepo requirementsRepo,
            IDashboardRepo dashboardRepo, IAssignRequirmentToItemRepo assignRequirmentToItemRepo ,
            ITransactionItemRepo transactionItemRepo, IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo,
            IAssignInquireytToItemRepo assignInquireytToItemRepo, ITransactionItemInquiryReop transactionItemInquiryRepo,
            IRequestInquiry_AnswerRpo inquiryAnswerRpo, ITransiactionItem_SelectionRepo itemSelectionRepo, IAssignSelectionToItemRepo assignSelectionToItemRepo,
            IRequestSelection_Selectes requestSelectionSelectes, IHubContext<SignalrServer> signalrHub)
        {

            this.applicationTransaction_RequestRepo = applicationTransaction_RequestRepo;
            this.application_StatusRepo = application_StatusRepo;
            this.appliactionTransferRepo = appliactionTransferRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.applicationTransaction_Request_LogRepo = applicationTransaction_Request_LogRepo;
            this.requirementsRepo = requirementsRepo;
            this.dashboardRepo = dashboardRepo;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.transactionItemRepo = transactionItemRepo;
            this.requirmentsFileAttachmentRepo = requirmentsFileAttachmentRepo;
            _assignInquireytToItemRepo = assignInquireytToItemRepo;
            _transactionItemInquiryRepo = transactionItemInquiryRepo;
            _inquiryAnswerRpo = inquiryAnswerRpo;
            _itemSelectionRepo = itemSelectionRepo;
            _assignSelectionToItemRepo = assignSelectionToItemRepo;
            _requestSelectionSelectes = requestSelectionSelectes;
            _userManager = userManager;
            _signalrHub = signalrHub;
        }
      [Authorize(Permissions.Dashboard_Permissions.View)]
        //  [ValidateAntiForgeryToken]
        public IActionResult Index()
        {

            //   Response.Headers.Add("Refresh", "5");
            
            DashboardVM DashboardVM = new DashboardVM();
            DashboardVM.NewRequest_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 0);
            DashboardVM.RequestSubmation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 1);
            DashboardVM.RequsetToPayment_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 2);
            DashboardVM.RequestPaymentDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 3);
            DashboardVM.RequestUnderProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 4);
            DashboardVM.RequestDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 5);
            DashboardVM.RequestMissingInformation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 6);
            DashboardVM.RequestMissingProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 7);
            DashboardVM.RequestRejectFromUS_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 8);
            DashboardVM.RequestRejectFromEntity_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 9);
            DashboardVM.RequestTransferAllUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10);
            DashboardVM.RequestTransferOneUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10 && a.TransferUserTo == User.FindFirstValue(ClaimTypes.NameIdentifier));
            DashboardVM.RequestAll_count = applicationTransaction_RequestRepo.GetAll().Count();
            //_signalrHub.Clients.All.SendAsync("loadRequests");
            return View(DashboardVM);
        }
        [HttpGet]
        public IActionResult loadRequest()
        {
            var data = applicationTransaction_RequestRepo.GetAll().Select(r => new DashboardVM()
            {
                NewRequest_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 0),
                RequestSubmation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 1),
                RequsetToPayment_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 2),
                RequestPaymentDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 3),
                RequestUnderProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 4),
                RequestDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 5),
                RequestMissingInformation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 6),
                RequestMissingProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 7),
                RequestRejectFromUS_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 8),
                RequestRejectFromEntity_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 9),
                RequestTransferAllUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10),
                RequestTransferOneUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10 && a.TransferUserTo == User.FindFirstValue(ClaimTypes.NameIdentifier)),
                RequestAll_count = applicationTransaction_RequestRepo.GetAll().Count(),
            }).ToList();
            //DashboardVM DashboardVM = new DashboardVM();
            //DashboardVM.NewRequest_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 0);
            //DashboardVM.RequestSubmation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 1);
            //DashboardVM.RequsetToPayment_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 2);
            //DashboardVM.RequestPaymentDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 3);
            //DashboardVM.RequestUnderProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 4);
            //DashboardVM.RequestDone_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 5);
            //DashboardVM.RequestMissingInformation_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 6);
            //DashboardVM.RequestMissingProcessing_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 7);
            //DashboardVM.RequestRejectFromUS_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 8);
            //DashboardVM.RequestRejectFromEntity_count = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 9);
            //DashboardVM.RequestTransferAllUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10);
            //DashboardVM.RequestTransferOneUser = applicationTransaction_RequestRepo.GetAll().Count(a => a.Status == 10 && a.TransferUserTo == User.FindFirstValue(ClaimTypes.NameIdentifier));
            //DashboardVM.RequestAll_count = applicationTransaction_RequestRepo.GetAll().Count();
            return Ok(data);
        }
        private string ProcessUploadedFile(ApplicationTransaction_RequestVM model)
        {
            string uniqueFileName = null;
            string path = Directory.GetCurrentDirectory() + "/wwwroot/UploadFilesTransactionLog/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.files_Upload != null)
            {
                string uploadsFolder = Directory.GetCurrentDirectory() + "/wwwroot/UploadFilesTransactionLog/";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.files_Upload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.files_Upload.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        //    [Authorize(Permissions.Dashboard.View)]
        //    [ValidateAntiForgeryToken]
        [Authorize(Permissions.Dashboard_Permissions.GetAppLicationByStatus)]
        [Route("/Dashboard/GetAppLicationByStatus/{status}")]
        public async Task<IActionResult> GetAppLicationByStatus(int status)
        {
            //Response.Headers.Add("Refresh", "5");
            var data = dashboardRepo.GetAllTransactiocByStatus(status).Select(a => new ApplicationTrans_RequestVM
            {
                ID = a.ID,
                ClientName = a.ClientName,
                ClientPhone = a.ClientPhone,
                UserEmail = a.UserEmail,
                The_Date = a.The_Date,
                Country_Name=a.Country_Name,
                TransiactionItem_Code = a.TransiactionItem_Code,
                TransiactionItem_Name = a.TransiactionItem_Name,
                TransiactionItem_NameEnglish =transactionItemRepo.GetAll().Where(c=>c.ID==a.TransiactionItem_Code).Select(a=>a.TransactionNameEnglish).FirstOrDefault(),
                TransiactionItem_Price = a.TransiactionItem_Price,
                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                TransiactionItem_Net = a.TransiactionItem_Net,
                NumberOfTransiactionOfEntity=a.NumberOfTransiactionOfEntity,
                Status=a.Status
            }).OrderByDescending(a=>a.The_Date).ToList();
            await _signalrHub.Clients.All.SendAsync("RefreshRequest");
            return View(data);

        }


        [HttpGet]
        [Route("/Dashboard/GetAppLicationBySignalRStatus/{status}")]
        public IActionResult GetAppLicationBySignalRStatus(int status)
        {
            //Response.Headers.Add("Refresh", "5");
            var data = dashboardRepo.GetAllTransactiocByStatus(status).Select(a => new ApplicationTrans_RequestVM
            {
                ID = a.ID,
                ClientName = a.ClientName,
                ClientPhone = a.ClientPhone,
                UserEmail = a.UserEmail,
                The_Date = a.The_Date,
                Country_Name = a.Country_Name,
                TransiactionItem_Code = a.TransiactionItem_Code,
                TransiactionItem_Name = a.TransiactionItem_Name,
                TransiactionItem_NameEnglish = transactionItemRepo.GetAll().Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish).FirstOrDefault(),
                TransiactionItem_Price = a.TransiactionItem_Price,
                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                TransiactionItem_Net = a.TransiactionItem_Net,
                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                Status = a.Status
            }).OrderByDescending(a => a.The_Date).ToList();
            return Ok(data);
        }

        /// <summary>
        /// to do
        /// </summary>
        /// <returns></returns>

        [Authorize(Permissions.Dashboard_Permissions.GetAppLicationByStatus)]
        public IActionResult GetAllAppLicationTransferByStatus()
        {
            var data = dashboardRepo.GetAllTransactioc().Where(a=>a.Status==10).Select(a => new ApplicationTrans_RequestVM
            {
                ID = a.ID,
                ClientName = a.ClientName,
                ClientPhone = a.ClientPhone,
                UserEmail = a.UserEmail,
                The_Date = a.The_Date,
                Country_Name = a.Country_Name,
                TransiactionItem_Code = a.TransiactionItem_Code,
                TransiactionItem_Name = a.TransiactionItem_Name,
                TransiactionItem_NameEnglish = transactionItemRepo.GetAll().Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish).FirstOrDefault(),
                TransiactionItem_Price = a.TransiactionItem_Price,
                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                TransiactionItem_Net = a.TransiactionItem_Net,
                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status),
                TarnferUserFrom_Name = _userManager.Users.Where(c => c.Id == a.TarnferUserFrom).Select(a => a.UserName).FirstOrDefault(),
                TransferUserTo_Name= _userManager.Users.Where(c => c.Id == a.TransferUserTo).Select(a => a.UserName).FirstOrDefault()



            }).ToList();
            return View(data);
        }

        [Authorize(Permissions.Dashboard_Permissions.GetAppLicationByStatus)]
        public IActionResult GetAllAppLicationTransferByUser()
        {
            var data = dashboardRepo.GetAllTransactioc().Where(a => a.Status == 10 && a.TransferUserTo== User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => new ApplicationTrans_RequestVM
            {
                ID = a.ID,
                ClientName = a.ClientName,
                ClientPhone = a.ClientPhone,
                UserEmail = a.UserEmail,
                The_Date = a.The_Date,
                Country_Name = a.Country_Name,
                TransiactionItem_Code = a.TransiactionItem_Code,
                TransiactionItem_Name = a.TransiactionItem_Name,
                TransiactionItem_NameEnglish = transactionItemRepo.GetAll().Where(c => c.ID == a.TransiactionItem_Code).Select(a => a.TransactionNameEnglish).FirstOrDefault(),
                TransiactionItem_Price = a.TransiactionItem_Price,
                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                TransiactionItem_Net = a.TransiactionItem_Net,
                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity,
                Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status),
                TarnferUserFrom_Name = _userManager.Users.Where(c => c.Id == a.TarnferUserFrom).Select(a => a.UserName).FirstOrDefault(),
                TransferUserTo_Name = _userManager.Users.Where(c => c.Id == a.TransferUserTo).Select(a => a.UserName).FirstOrDefault()



            }).ToList();
            return View(data);
        }

        [Authorize(Permissions.Dashboard_Permissions.GetAllAppLication)]
        public IActionResult GetAllAppLication()
        {
            var data = dashboardRepo.GetAllTransactioc().Select(a => new ApplicationTrans_RequestVM
            {
                ID = a.ID,
                ClientName = a.ClientName,
                ClientPhone = a.ClientPhone,
                UserEmail = a.UserEmail,
                The_Date = a.The_Date,
                TransiactionItem_Code = a.TransiactionItem_Code,
                TransiactionItem_Name = a.TransiactionItem_Name,
                TransiactionItem_NameEnglish=transactionItemRepo.GetAll().Where(c=>c.ID== a.TransiactionItem_Code).Select(a=>a.TransactionNameEnglish).FirstOrDefault(),
                TransiactionItem_Price = a.TransiactionItem_Price,
                TransiactionItem_GovernmentFees = a.TransiactionItem_GovernmentFees,
                TransiactionItem_Net = a.TransiactionItem_Net,
                Status_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status) ,
               
                NumberOfTransiactionOfEntity = a.NumberOfTransiactionOfEntity
            }).ToList();
            return View(data);
        }
        [HttpGet]
        [Route("/Dashboard/checkTransactTimes/{id}")]
        public IActionResult checkTransactTimes(Guid id)
        {
            var data = applicationTransaction_RequestRepo.GetAllProcessing()
                .Where(a=>a.App_Code== id)
                .Select(a => new ApplicationTransaction_Request_ProcessingVM()
                {
                    ID = a.ID,
                    StartTransactionTime = a.StartTransactionTime,
                    EndTransactionTime = a.EndTransactionTime,
                   
                     TimeEnd = (a.EndTransactionTime - DateTime.Now).Minutes,
                    //TimeEnd = 
                    UserID = a.UserID
                }).ToList();

            return Ok(data);
        } 


        [HttpPost]
        public async Task<IActionResult> CheckRequestApplicationToOpen(ApplicationTransaction_RequestVM objVm)
        {
            objVm.EndTransactionTime = applicationTransaction_RequestRepo.GetAllProcessing().Where(a =>
                 a.ID == objVm.ProsessID).Select(a => a.EndTransactionTime).FirstOrDefault();

            objVm.StartTransactionTime = applicationTransaction_RequestRepo.GetAllProcessing().Where(a =>
                a.ID == objVm.ProsessID).Select(a => a.StartTransactionTime).FirstOrDefault();

            switch (objVm.IsProsessByUser)
            {

                   

                case 0:
                {
                    ApplicationTransaction_Request_Processing processingVm = new ApplicationTransaction_Request_Processing();
                    processingVm.App_Code = objVm.ID;
                    processingVm.StartTransactionTime = DateTime.Now;
                    processingVm.EndTransactionTime = DateTime.Now + TimeSpan.FromMinutes(10);
                    processingVm.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    processingVm.ActiveStatus = 0;
                    await applicationTransaction_RequestRepo.UpdateRequestToProcess(processingVm);
                    
                    ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
                    updateObj.ID=objVm.ID;
                    updateObj.IsProsessByUser = 1;
                    updateObj.UserProsessID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    updateObj.ProsessID = processingVm.ID;

                   
                   

                  
                    await applicationTransaction_RequestRepo.UpdateApplicationToNewProcess(updateObj);


                        var users = _userManager.Users.Where(a => a.UserType == 1)
                        .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                        .ToList();




                    ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

                    var data = dashboardRepo.GetByAPPCode(objVm.ID);
                    ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
                    obj.ID = data.ID;
                    obj.ClientName = data.ClientName;
                    obj.ClientPhone = data.ClientPhone;
                    obj.UserEmail = data.UserEmail;
                    obj.The_Date = data.The_Date;
                    obj.TransiactionItem_Code = data.TransiactionItem_Code;
                    obj.TransiactionItem_Name = data.TransiactionItem_Name;
                    obj.TransiactionItem_Price = data.TransiactionItem_Price;
                    obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
                    obj.TransiactionItem_Net = data.TransiactionItem_Net;
                    obj.ClientNotes = data.ClientNotes;
                    obj.files = data.files;
                    obj.Status = data.Status;
                    obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
                    obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
                    {
                        RequirmentID = m.ID,

                        Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

                    });
                    obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
                    {
                        The_Date = a.The_Date,
                        User_Code = a.User_Code,
                        User_Name = a.User_Name,
                        Status_From_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_From),
                        Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO),

                        Note = a.Note,
                        File_Processing = a.File_Processing,
                        File_Name = a.File_Name

                    });
                    obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
                    {
                        Transfer_Date = a.Transfer_Date,
                        userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                        userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()

                    });


                    obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == objVm.ID).Select(c => new RequirmentsFileAttachmentVM()
                    {
                        RequireID = c.RequireID,
                        RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                        FileName = c.FileName
                    }).ToList();
                    obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == objVm.ID).Select(w =>
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
                        }).ToList();
                    obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == objVm.ID && n.IsSelected == true).Select(
                        m => new RequestSelectionVM()
                        {

                            SelectionID = m.SelectionID,
                            SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                            SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                .Select(c => c.SelectionName_English).FirstOrDefault(),
                            IsSelected = m.IsSelected

                        }).ToList();



                    return RedirectToAction("GetAppLicationToReview",  new { id = obj.ID.ToString() }) ;
                }
                  
                case 1 when ( objVm.UserProsessID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
                            (DateTime.Now - objVm.StartTransactionTime ).TotalMinutes  <= 10):
                {
                   
                        


                    var users = _userManager.Users.Where(a => a.UserType == 1)
                        .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                        .ToList();




                    ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

                    var data = dashboardRepo.GetByAPPCode(objVm.ID);
                    ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
                    obj.ID = data.ID;
                    obj.ClientName = data.ClientName;
                    obj.ClientPhone = data.ClientPhone;
                    obj.UserEmail = data.UserEmail;
                    obj.The_Date = data.The_Date;
                    obj.TransiactionItem_Code = data.TransiactionItem_Code;
                    obj.TransiactionItem_Name = data.TransiactionItem_Name;
                    obj.TransiactionItem_Price = data.TransiactionItem_Price;
                    obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
                    obj.TransiactionItem_Net = data.TransiactionItem_Net;
                    obj.ClientNotes = data.ClientNotes;
                    obj.files = data.files;
                    obj.Status = data.Status;
                    obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
                    obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
                    {
                        RequirmentID = m.ID,

                        Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

                    });
                    obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
                    {
                        The_Date = a.The_Date,
                        User_Code = a.User_Code,
                        User_Name = a.User_Name,
                        Status_From_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_From),
                        Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO),

                        Note = a.Note,
                        File_Processing = a.File_Processing,
                        File_Name = a.File_Name

                    });
                    obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
                    {
                        Transfer_Date = a.Transfer_Date,
                        userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                        userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()

                    });


                    obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == objVm.ID).Select(c => new RequirmentsFileAttachmentVM()
                    {
                        RequireID = c.RequireID,
                        RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                        FileName = c.FileName
                    }).ToList();
                    obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == objVm.ID).Select(w =>
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
                        }).ToList();
                    obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == objVm.ID && n.IsSelected == true).Select(
                        m => new RequestSelectionVM()
                        {

                            SelectionID = m.SelectionID,
                            SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                            SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                .Select(c => c.SelectionName_English).FirstOrDefault(),
                            IsSelected = m.IsSelected

                        }).ToList();
                    return RedirectToAction("GetAppLicationToReview", new { id = obj.ID.ToString() });
                }

                case 1 when objVm.UserProsessID != User.FindFirstValue(ClaimTypes.NameIdentifier) &&
                           (DateTime.Now -  objVm.StartTransactionTime  ).TotalMinutes >= 10:
                {


                        ApplicationTransaction_Request_Processing processingVm = new ApplicationTransaction_Request_Processing();
                        processingVm.App_Code = objVm.ID;
                        processingVm.StartTransactionTime = DateTime.Now;
                        processingVm.EndTransactionTime = DateTime.Now + TimeSpan.FromMinutes(10);
                        processingVm.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        processingVm.ActiveStatus = 0;
                        await applicationTransaction_RequestRepo.UpdateRequestToProcess(processingVm);

                        ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
                        updateObj.ID = objVm.ID;
                        updateObj.IsProsessByUser = 1;
                        updateObj.UserProsessID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        updateObj.ProsessID = processingVm.ID;





                        await applicationTransaction_RequestRepo.UpdateApplicationToNewProcess(updateObj);

                        var users = _userManager.Users.Where(a => a.UserType == 1)
                            .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                            .ToList();




                        ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

                        var data = dashboardRepo.GetByAPPCode(objVm.ID);
                        ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
                        obj.ID = data.ID;
                        obj.ClientName = data.ClientName;
                        obj.ClientPhone = data.ClientPhone;
                        obj.UserEmail = data.UserEmail;
                        obj.The_Date = data.The_Date;
                        obj.TransiactionItem_Code = data.TransiactionItem_Code;
                        obj.TransiactionItem_Name = data.TransiactionItem_Name;
                        obj.TransiactionItem_Price = data.TransiactionItem_Price;
                        obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
                        obj.TransiactionItem_Net = data.TransiactionItem_Net;
                        obj.ClientNotes = data.ClientNotes;
                        obj.files = data.files;
                        obj.Status = data.Status;
                        obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
                        obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
                        {
                            RequirmentID = m.ID,

                            Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                            Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

                        });
                        obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
                        {
                            The_Date = a.The_Date,
                            User_Code = a.User_Code,
                            User_Name = a.User_Name,
                            Status_From_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_From),
                            Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO),

                            Note = a.Note,
                            File_Processing = a.File_Processing,
                            File_Name = a.File_Name

                        });
                        obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
                        {
                            Transfer_Date = a.Transfer_Date,
                            userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                            userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()

                        });


                        obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == objVm.ID).Select(c => new RequirmentsFileAttachmentVM()
                        {
                            RequireID = c.RequireID,
                            RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                            RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                            FileName = c.FileName
                        }).ToList();
                        obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == objVm.ID).Select(w =>
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
                            }).ToList();
                        obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == objVm.ID && n.IsSelected == true).Select(
                            m => new RequestSelectionVM()
                            {

                                SelectionID = m.SelectionID,
                                SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                    .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                                SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                    .Select(c => c.SelectionName_English).FirstOrDefault(),
                                IsSelected = m.IsSelected

                            }).ToList();
                        return RedirectToAction("GetAppLicationToReview", new { id = obj.ID.ToString() });
                    }

                case 1 when objVm.UserProsessID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
               (DateTime.Now -  objVm.EndTransactionTime ).TotalMinutes >= 60:
                {

                        ApplicationTransaction_Request_Processing processingVm = new ApplicationTransaction_Request_Processing();
                        processingVm.App_Code = objVm.ID;
                        processingVm.StartTransactionTime = DateTime.Now;
                        processingVm.EndTransactionTime = DateTime.Now + TimeSpan.FromMinutes(10);
                        processingVm.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        processingVm.ActiveStatus = 0;
                        await applicationTransaction_RequestRepo.UpdateRequestToProcess(processingVm);

                        ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
                        updateObj.ID = objVm.ID;
                        updateObj.IsProsessByUser = 1;
                        updateObj.UserProsessID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        updateObj.ProsessID = processingVm.ID;





                        await applicationTransaction_RequestRepo.UpdateApplicationToNewProcess(updateObj);



                        var users = _userManager.Users.Where(a => a.UserType == 1)
                            .Select(user => new UserViewModel
                                {   Id = user.Id, 
                                    UserName = user.UserName, 
                                    Email = user.Email, 
                                    Roles = _userManager.GetRolesAsync(user).Result })
                            .ToList();




                        ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

                        var data = dashboardRepo.GetByAPPCode(objVm.ID);
                        ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
                        obj.ID = data.ID;
                        obj.ClientName = data.ClientName;
                        obj.ClientPhone = data.ClientPhone;
                        obj.UserEmail = data.UserEmail;
                        obj.The_Date = data.The_Date;
                        obj.TransiactionItem_Code = data.TransiactionItem_Code;
                        obj.TransiactionItem_Name = data.TransiactionItem_Name;
                        obj.TransiactionItem_Price = data.TransiactionItem_Price;
                        obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
                        obj.TransiactionItem_Net = data.TransiactionItem_Net;
                        obj.ClientNotes = data.ClientNotes;
                        obj.files = data.files;
                        obj.Status = data.Status;
                        obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
                        obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
                        {
                            RequirmentID = m.ID,

                            Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                            Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

                        });
                        obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
                        {
                            The_Date = a.The_Date,
                            User_Code = a.User_Code,
                            User_Name = a.User_Name,
                            Status_From_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_From),
                            Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO),

                            Note = a.Note,
                            File_Processing = a.File_Processing,
                            File_Name = a.File_Name

                        });
                        obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
                        {
                            Transfer_Date = a.Transfer_Date,
                            userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                            userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()

                        });


                        obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == objVm.ID).Select(c => new RequirmentsFileAttachmentVM()
                        {
                            RequireID = c.RequireID,
                            RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                            RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                            FileName = c.FileName
                        }).ToList();
                        obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == objVm.ID).Select(w =>
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
                            }).ToList();
                        obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == objVm.ID && n.IsSelected == true).Select(
                            m => new RequestSelectionVM()
                            {

                                SelectionID = m.SelectionID,
                                SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                    .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                                SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                                    .Select(c => c.SelectionName_English).FirstOrDefault(),
                                IsSelected = m.IsSelected

                            }).ToList();
                        return RedirectToAction("GetAppLicationToReview", new { id = obj.ID.ToString() });
                    }
                default:
                    return View();
            }
        }

        

       

        public  IActionResult CheckRequestApplicationToOpen(Guid ID)
        {






            var users =  _userManager.Users.Where(a=>a.UserType==1)
               .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
               .ToList();

          


            ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

            var data = dashboardRepo.GetByAPPCode(ID);
            ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
            obj.ID = data.ID;
            obj.ClientName = data.ClientName;
            obj.ClientPhone = data.ClientPhone;
            obj.UserEmail = data.UserEmail;
            obj.The_Date = data.The_Date;
            obj.TransiactionItem_Code = data.TransiactionItem_Code;
            obj.TransiactionItem_Name = data.TransiactionItem_Name;
            obj.TransiactionItem_Price = data.TransiactionItem_Price;
            obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
            obj.TransiactionItem_Net = data.TransiactionItem_Net;
            obj.ClientNotes = data.ClientNotes;
            obj.files = data.files;
            obj.Status = data.Status;
            obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
            obj.IsProsessByUser = data.IsProsessByUser;
            obj.UserProsessID = data.UserProsessID;
            if (data.ProsessID != null) obj.ProsessID = (int)data.ProsessID;
            obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
            {
                RequirmentID = m.ID,
                
                Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

            });
            obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
            {
                The_Date = a.The_Date,
                User_Code = a.User_Code,
                User_Name = a.User_Name,
                Status_From_Name = application_StatusRepo.GetStatusTransfer_Name( a.Status_From),
                Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO) ,
                
                Note = a.Note,
                File_Processing = a.File_Processing,
                File_Name=a.File_Name

            });
            obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
            {
                Transfer_Date = a.Transfer_Date,
                userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()
                
            });


            obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == ID).Select(c => new RequirmentsFileAttachmentVM()
            {
                RequireID = c.RequireID,
                RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                FileName= c.FileName
            }).ToList();
            obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == ID).Select(w =>
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
                }).ToList();
            obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == ID && n.IsSelected==true).Select(
                m => new RequestSelectionVM()
                {

                    SelectionID = m.SelectionID,
                    SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                    SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_English).FirstOrDefault(),
                    IsSelected = m.IsSelected

                }).ToList();
            obj.ApplicationTransaction_Request_ProcessingVM = applicationTransaction_RequestRepo.GetAllProcessing()
                .Where(a=>a.App_Code==ID)
                .Select(a => new ApplicationTransaction_Request_ProcessingVM
                {
                    ID = a.ID,
                    UserID = a.UserID,
                    App_Code = a.App_Code,
                    StartTransactionTime = a.StartTransactionTime,
                    EndTransactionTime = a.EndTransactionTime,

                }).ToList();



            if (applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID)== null)
            {
                return View(obj);
            }

            if(applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).UserID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
               (DateTime.Now - applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).EndTransactionTime  ) <= TimeSpan.FromMinutes(10))
            {
                return  View(obj);
            }

            if (applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).UserID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
                (DateTime.Now - applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).EndTransactionTime ) >= TimeSpan.FromMinutes(10))
            {
                return View(obj);
            }

            if (applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).UserID == User.FindFirstValue(ClaimTypes.NameIdentifier) &&
                (DateTime.Now - applicationTransaction_RequestRepo.GetAllProcessingByAppId(ID).EndTransactionTime) >= TimeSpan.FromMinutes(10))
            {
                return View(obj);
            }







            else
            {
                return View(obj);
            }

        }


        [HttpGet]
        //[HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.GetAppLicationToReview)]
        //  [Route("Dashboard/GetAppLicationToReview/{AppCode}")]
        public async Task<IActionResult> GetAppLicationToReview(Guid ID)
        {
            var users =  _userManager.Users.Where(a=>a.UserType==1)
               .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
               .ToList();

          


            ViewBag.getAlluser = new SelectList(users, "Id", "UserName");

            var data = dashboardRepo.GetByAPPCode(ID);
            ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();
            obj.ID = data.ID;
            obj.ClientName = data.ClientName;
            obj.ClientPhone = data.ClientPhone;
            obj.UserEmail = data.UserEmail;
            obj.The_Date = data.The_Date;
            obj.TransiactionItem_Code = data.TransiactionItem_Code;
            obj.TransiactionItem_Name = data.TransiactionItem_Name;
            obj.TransiactionItem_Price = data.TransiactionItem_Price;
            obj.TransiactionItem_GovernmentFees = data.TransiactionItem_GovernmentFees;
            obj.TransiactionItem_Net = data.TransiactionItem_Net;
            obj.ClientNotes = data.ClientNotes;
            obj.files = data.files;
            obj.Status = data.Status;
            obj.NumberOfTransiactionOfEntity = data.NumberOfTransiactionOfEntity;
            obj.AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == data.TransiactionItem_Code).Select(m => new AssignRequirmentToItemVM
            {
                RequirmentID = m.ID,
                
                Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

            });
            obj.ApplicationTransaction_Request_LogVM = applicationTransaction_Request_LogRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransaction_Request_LogVM
            {
                The_Date = a.The_Date,
                User_Code = a.User_Code,
                User_Name = a.User_Name,
                Status_From_Name = application_StatusRepo.GetStatusTransfer_Name( a.Status_From),
                Status_TO_Name = application_StatusRepo.GetStatusTransfer_Name(a.Status_TO) ,
                
                Note = a.Note,
                File_Processing = a.File_Processing,
                File_Name=a.File_Name

            });
            obj.ApplicationTransferVm = appliactionTransferRepo.GetByAppCode(data.ID).Select(a => new ApplicationTransferVm
            {
                Transfer_Date = a.Transfer_Date,
                userFrom_Name = _userManager.Users.Where(c => c.Id == a.userFrom).Select(a => a.UserName).FirstOrDefault(),
                userTo = _userManager.Users.Where(c => c.Id == a.userTo).Select(a => a.UserName).FirstOrDefault()
                
            });


            obj.RequirmentsFileAttachmentVM = requirmentsFileAttachmentRepo.GetAll().Where(r => r.App_Code == ID).Select(c => new RequirmentsFileAttachmentVM()
            {
                RequireID = c.RequireID,
                RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequireID).Select(a => a.RequirementName_English).FirstOrDefault(),
                FileName= c.FileName
            }).ToList();
            obj.RequestInquiry_Answer_VM = _inquiryAnswerRpo.GetAll().Where(y => y.App_Code == ID).Select(w =>
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
                }).ToList();
            obj.RequestSelectionVM = _requestSelectionSelectes.GetAll().Where(n => n.App_Code == ID && n.IsSelected==true).Select(
                m => new RequestSelectionVM()
                {

                    SelectionID = m.SelectionID,
                    SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                    SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_English).FirstOrDefault(),
                    IsSelected = m.IsSelected

                }).ToList();
           

            ApplicationTransaction_Request_ProcessingVM processingVm = new ApplicationTransaction_Request_ProcessingVM();

            if (processingVm.App_Code == ID)
            {

            }
            //BackgroundJob.Schedule(() => EndSessision(), TimeSpan.FromMinutes(1));
            await _signalrHub.Clients.All.SendAsync("checkTransactTime");
            return View(obj);
         


        }

        public  IActionResult GetAplicationToProcessing (ApplicationTransaction_Request_ProcessingVM obj)
        {
            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            //updateObj.ID  = obj.ID;
            return Ok(updateObj);

        }

        [Authorize(Permissions.Dashboard_Permissions.View)]
        public FileResult DownloadFile(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }


        [Authorize(Permissions.Dashboard_Permissions.View)]
        public FileResult DownloadFileLog(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFilesTransactionLog/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }

        [Authorize(Permissions.Dashboard_Permissions.View)]
        public FileResult DownloadFileRequirmentApplication(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }


        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToSubmation)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateObjToSubmation(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateObjToSubmation(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            var value = obj.Note;
            addlog.Note = value; 
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 1;

            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name=obj.File_Name;
            }

            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");
            await _signalrHub.Clients.All.SendAsync("RefreshRequest");




            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToPayment)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateObjToPayment(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateObjToPayment(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 2;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");
            await _signalrHub.Clients.All.SendAsync("RefreshRequest");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToPaymentDone)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateObjToPaymentDone(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateObjToPaymentDone(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From =obj.Status;
            addlog.Status_TO = 3;

            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestUnderProcessing)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusUnderProcessing(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            updateObj.NumberOfTransiactionOfEntity=obj.NumberOfTransiactionOfEntity;
            await applicationTransaction_RequestRepo.UpdateStatusUnderProcessing(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 4;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToDone)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusToDone(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateStatusToDone(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 5;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToMissingInformation)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusToMissingInformation(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateStatusToMissingInformation(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 6;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestToMissingProcessing)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusToMissingProcessing(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateStatusToMissingProcessing(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 6;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestRejectFromUS)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusRejectFromUS(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateStatusRejectFromUS(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 8;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestRejectFromEntity)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusRejectFromEntity(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            await applicationTransaction_RequestRepo.UpdateStatusRejectFromEntity(updateObj);

            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 9;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);
            await _signalrHub.Clients.All.SendAsync("loadRequests");





            return RedirectToAction("index");
        }
/// ediit permim to  do
        [HttpPost]
        [Authorize(Permissions.Dashboard_Permissions.UpdateRequestRejectFromEntity)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatusToTransfer(ApplicationTransaction_RequestVM obj)
        {

            ApplicationTransaction_Request updateObj = new ApplicationTransaction_Request();
            updateObj.ID = obj.ID;
            updateObj.TarnferUserFrom= User.FindFirstValue(ClaimTypes.NameIdentifier);
            updateObj.TransferUserTo=obj.userTo;
            await applicationTransaction_RequestRepo.UpdateStatusToTransfer(updateObj);
            
            ApplicationTransaction_Request_Log addlog = new ApplicationTransaction_Request_Log();

            var item = obj.ApplicationTransaction_Request_LogVM;

            addlog.The_Date = DateTime.Now;
            addlog.User_Name = User.FindFirstValue(ClaimTypes.Name);
            addlog.User_Code = User.FindFirstValue(ClaimTypes.NameIdentifier);

            addlog.App_Code = obj.ID;
            addlog.Note = obj.Note;
            addlog.Status_From = obj.Status;
            addlog.Status_TO = 9;
            if (obj.files_Upload != null)
            {


                addlog.File_Processing = ProcessUploadedFile(obj);
                addlog.File_Name = obj.File_Name;
            }
            await applicationTransaction_Request_LogRepo.AddObj(addlog);

            if (obj.IsTransfer == true)
            {
                ApplicationTransfer addtransferobj = new ApplicationTransfer();
                addtransferobj.App_Code = obj.ID;
                addtransferobj.userFrom = User.FindFirstValue(ClaimTypes.NameIdentifier);
                addtransferobj.userTo = obj.userTo;
                addtransferobj.Transfer_Date = obj.Transfer_Date;
                addtransferobj.Status = 1;
                addtransferobj.Transfer_Date = DateTime.Now;
                await appliactionTransferRepo.AddObj(addtransferobj);
                await _signalrHub.Clients.All.SendAsync("loadRequests");
            }




            return RedirectToAction("index");
        }

        [Authorize(Permissions.Dashboard_Permissions.GetAllSubservicesInfo)]
       
        public IActionResult GetAllItemsInfo()
        {
            var data = transactionItemRepo.GetAll().Select(a => new TransactionItemInfoVM()
            {
                ID = a.ID,
                TransactionNameArabic = a.TransactionNameArabic,
                TransactionNameEnglish = a.TransactionNameEnglish,
                GovernmentFees = a.GovernmentFees,
                Price = a.Price,
                TransactionGroupName = transactionGroupRepo.GetAll().Where(g=>g.ID==a.TransactionGroupID).Select(m=>m.TransactionGroup_NameArabic).FirstOrDefault(),
                TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID).Select(m => m.TransactionGroup_NameEnglish).FirstOrDefault(),
                TransactionSubGroupName = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameArabic).FirstOrDefault(),
                TransactionSubGroupNameEnglish= transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameEnglish).FirstOrDefault(),
                Groupimage = transactionGroupRepo.GetAll().Where(x=>x.ID== a.TransactionGroupID).Select(a=>a.logo).FirstOrDefault(),
                AssignRequirmentToItemVM= assignRequirmentToItemRepo.GetAll().Where(x=>x.TransactionItemID==a.ID).Select(m=> new AssignRequirmentToItemVM()
                {
                    Requirements_NameArabic=requirementsRepo.GetAll().Where(s=>s.ID==m.RequirmentID).Select(c=>c.RequirementName_Arabic).FirstOrDefault(),
                    Requirements_English= requirementsRepo.GetAll().Where(s => s.ID == m.RequirmentID).Select(c => c.RequirementName_English).FirstOrDefault()
                })


            }) ;
            return View(data);
        }


    }

}
