using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using GSI_Internal.Migrations;
using GSI_Internal.Repositry.Client_WalletRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ApplicationTransaction_Request = GSI_Internal.Entites.ApplicationTransaction_Request;
using client_wallet = GSI_Internal.Entites.client_wallet;
using RequestInquiry_Answer = GSI_Internal.Entites.RequestInquiry_Answer;
using RequestSelection = GSI_Internal.Entites.RequestSelection;

namespace GSI_Internal.Controllers
{
    public class ApplicationTransaction_RequestController : Controller
    {
        private readonly dbContainer db;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly IApplicationTransaction_RequestRepo applicationTransaction_RequestRepo;
        private readonly IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClientWalletRepo _clientWalletRepo;

        public ApplicationTransaction_RequestController(dbContainer db, IRequirementsRepo requirementsRepo,
            IAssignRequirmentToItemRepo assignRequirmentToItemRepo, ITransactionItemRepo transactionItemRepo,
            IApplicationTransaction_RequestRepo applicationTransaction_RequestRepo,
            IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo ,
            UserManager<ApplicationUser> _userManager,IClientWalletRepo clientWalletRepo)
        {
            this.db = db;
            this.requirementsRepo = requirementsRepo;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.transactionItemRepo = transactionItemRepo;
            this.applicationTransaction_RequestRepo = applicationTransaction_RequestRepo;
            this.requirmentsFileAttachmentRepo = requirmentsFileAttachmentRepo;
            this._userManager = _userManager;
            _clientWalletRepo = clientWalletRepo;
        }
        [AllowAnonymous]
        public IActionResult Index(int id)
        {
            ViewBag.CountryList = from p in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures | CultureTypes.SpecificCultures).OrderBy(c => c.DisplayName)
                              select new SelectListItem
                              {
                                  Text = p.EnglishName,
                                  Value = p.DisplayName
                              };



            ApplicationTrans_RequestVM data = new ApplicationTrans_RequestVM()
            {
                TransactionItemVM = transactionItemRepo.GetAll().Where(a => a.ID == id).Select(x =>
                new TransactionItemVM
                {
                    ID = x.ID,
                    TransactionNameArabic = transactionItemRepo.GetAll().Where(m => m.ID == x.ID).Select(a => a.TransactionNameArabic).FirstOrDefault(),
                    TransactionNameEnglish = transactionItemRepo.GetAll().Where(m => m.ID == x.ID).Select(a => a.TransactionNameEnglish).FirstOrDefault(),
                    GovernmentFees = transactionItemRepo.GetAll().Where(m => m.ID == x.ID).Select(a => a.GovernmentFees).FirstOrDefault(),
                    Price = transactionItemRepo.GetAll().Where(m => m.ID == x.ID).Select(a => a.Price).FirstOrDefault(),
                }),
                AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == id).Select(m => new AssignRequirmentToItemVM
                {
                    RequirmentID = m.ID,
                    Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                    Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == m.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),
                }),
                RequirmentsFileAttachmentVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == id).Select(c => new RequirmentsFileAttachmentVM()
                {
                    RequireID = c.RequirmentID,
                    RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID).Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                    RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID).Select(a => a.RequirementName_English).FirstOrDefault(),

                }).ToList()

                //   ApplicationTransaction_RequestVM = new ApplicationTransaction_RequestVM()

            };

            return View(data);
            //  return RedirectToAction("Index",data);
        }

    

        [HttpPost]
        [Route("ApplicationTransaction_Request/AjaxUpload")]
        public async  Task<JsonResult> AjaxUpload(int requireID, IFormFile FileNameFormFile)
        {
            client_wallet newwallet = new client_wallet();
            if (ModelState.IsValid)
            {
               
                newwallet.UserId = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newwallet.TheDateFile= DateTime.Now;
                newwallet.RequireID = requireID;
                //newwallet.FileName= 
                string uploadFilesAttachPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";
                string uploadFilesAttachename = (requirementsRepo.GetAll().Where(a => a.ID == requireID).Select(a => a.RequirementName_English).FirstOrDefault() + Guid.NewGuid().ToString() + "_" + System.IO.Path.GetExtension(FileNameFormFile.FileName));

                await using (var fileStream = new FileStream(Path.Combine(uploadFilesAttachPath, uploadFilesAttachename), FileMode.Create))
                {
                    await FileNameFormFile.CopyToAsync(fileStream);
                }

                newwallet.FileName = uploadFilesAttachename;
                _clientWalletRepo.AddObj(newwallet);


            }
            return Json(true);
       
    }
        [Route("ApplicationTransaction_Request/UploadImage")]
        [HttpPost]
        public  async Task<ActionResult> UploadImage()
        {
            string Result = string.Empty;

            var Files = Request.Form.Files;
            foreach (IFormFile source in Files)
            {
                string FileName = Guid.NewGuid() + System.IO.Path.GetFileName(source.FileName);
                string imagepath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";

                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                    await using (FileStream fileStream = System.IO.File.Create(imagepath))
                    {
                        await source.CopyToAsync(fileStream);
                        Result = "pass";

                    }

                }
            }


            return Ok();
        }


//[DisableRequestSizeLimit]
        [HttpPost]
        [AllowAnonymous]
       
        public async Task<IActionResult>   Create(ApplicationTrans_RequestVM obj)
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
                newobj.TransiactionItem_Name = transactionItemRepo.GetAll().Where(a=>a.ID== obj.TransiactionItem_Code).Select(a=>a.TransactionNameArabic).FirstOrDefault();
                newobj.TransiactionItem_Price = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.Price).FirstOrDefault();
                newobj.TransiactionItem_GovernmentFees = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.GovernmentFees).FirstOrDefault();
                newobj.TransiactionItem_Net = newobj.TransiactionItem_Price + newobj.TransiactionItem_GovernmentFees;
                newobj.ClientID= _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newobj.ClientName = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.FirstName)
                    .FirstOrDefault();
                newobj.ClientPhone = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.PhoneNumber)
                    .FirstOrDefault();

                newobj.ClientLastName = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.LastName)
                    .FirstOrDefault();

                newobj.Country_Name = " ";
                newobj.UserEmail = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Email)
                    .FirstOrDefault();

                newobj.The_Date = DateTime.Now;
                newobj.Move_Type = 1;
                newobj.Status = 0;
                newobj.NumberOfTransiactionOfEntity = "0";
                newobj.TarnferUserFrom = "";
                newobj.TransferUserTo = "";
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





                        newattachment.UserID = _userManager.Users
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

                

                applicationTransaction_RequestRepo.AddObj(newobj);
                FinishApplicationVM FinishApplicationVM = new FinishApplicationVM();
                FinishApplicationVM.App_ID = newobj.ID;
                FinishApplicationVM.ClientName = newobj.ClientName;
                FinishApplicationVM.ClientLastName = newobj.ClientLastName;
                return RedirectToAction("FinishApplication", FinishApplicationVM);

            }
            else
            {
                return View();
            }
           


        }

 

        [HttpPost]
        public  IActionResult CreateManualTransAction(ApplicationTrans_RequestVM obj)
        {

            ApplicationTransaction_Request newobj = new ApplicationTransaction_Request();
            //  obj.ApplicationTrans_RequestVM = JsonConvert.DeserializeObject<ApplicationTrans_RequestVM>(obj.ApplicationTrans_RequestVM);
            string UploadFilesPhotPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/UploadFiles/";
            string UploadFilesfilename = Guid.NewGuid() + System.IO.Path.GetFileName(obj.files_Upload.FileName);
            obj.files_Upload.CopyTo(new System.IO.FileStream(UploadFilesPhotPath + UploadFilesfilename, System.IO.FileMode.Create));

            newobj.TransiactionItem_Code = obj.TransiactionItem_Code;
            newobj.TransiactionItem_Name = transactionItemRepo.GetAll().Where(a=>a.ID== obj.TransiactionItem_Code).Select(a=>a.TransactionNameArabic).FirstOrDefault();
            newobj.TransiactionItem_Price = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.Price).FirstOrDefault();
            newobj.TransiactionItem_GovernmentFees = transactionItemRepo.GetAll().Where(a => a.ID == obj.TransiactionItem_Code).Select(a => a.GovernmentFees).FirstOrDefault();
            newobj.TransiactionItem_Net = newobj.TransiactionItem_Price + newobj.TransiactionItem_GovernmentFees;
            newobj.ClientName = obj.ClientName;
            newobj.ClientPhone = obj.ClientPhone;
            newobj.ClientLastName = obj.ClientLastName;
            newobj.Country_Name = obj.Country_Name;
            newobj.UserEmail = obj.UserEmail;
            newobj.The_Date = DateTime.Now;
            newobj.Move_Type = obj.Move_Type;
            newobj.Status = 0;

            newobj.files = UploadFilesfilename;
            applicationTransaction_RequestRepo.AddObj(newobj);
         
            return RedirectToAction("index", "Dashboard");

           

        }
        public IActionResult CreateManualTransAction()
        {
            ViewBag.selectsubservices = new SelectList(transactionItemRepo.GetAll().Select(a => a), "ID", "TransactionNameArabic", 1);



            return View();

        }

        [AllowAnonymous]
        public IActionResult FinishApplication(FinishApplicationVM obj)
        {
            //  ApplicationTransaction_RequestVM obj = new ApplicationTransaction_RequestVM();

            var data = db.ApplicationTransaction_Request.Find(obj.App_ID);
            obj.App_ID = data.ID;
            obj.ClientName = data.ClientName;
            obj.ClientLastName = data.ClientLastName;
           // obj.Country_Name = data.Country_Name;  


            return View(obj);


        }


    }
}
