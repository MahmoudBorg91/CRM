using GSI_Internal.Context;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.HomeRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GSI_Internal.Areas.Identity.Pages.Account;
using GSI_Internal.Entites;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using GSI_Internal.Repositry.SlideShowRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSI_Internal.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContainer db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHomeRepo homeRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo;
        private readonly IAssignInquireytToItemRepo _assignInquireytToItemRepo;
        private readonly ITransactionItemInquiryReop _transactionItemInquiryRepo;
        private readonly ITransiactionItem_SelectionRepo _itemSelectionRepo;
        private readonly IAssignSelectionToItemRepo _assignSelectionToItemRepo;
        private readonly IRequestSelection_GroupRepo _selectionGroupRepo;
        private readonly IApplicationTransaction_RequestRepo applicationTransactionRequestRepo;
        private readonly ISlideShowRepo _slideshowRepo;

        public HomeController(ILogger<HomeController> logger, dbContainer db, UserManager<ApplicationUser> userManager,
                              IHomeRepo homeRepo, IRequirementsRepo requirementsRepo, ITransactionItemRepo transactionItemRepo, 
                              IAssignRequirmentToItemRepo assignRequirmentToItemRepo   , ITransactionGroupRepo transactionGroupRepo,
                              ITransactionSubGroupRepo transactionSubGroupRepo, IRequirmentsFileAttachmentRepo requirmentsFileAttachmentRepo,
                              IAssignInquireytToItemRepo assignInquireytToItemRepo, ITransactionItemInquiryReop transactionItemInquiryRepo,
                              ITransiactionItem_SelectionRepo itemSelectionRepo, IAssignSelectionToItemRepo assignSelectionToItemRepo,
                              IRequestSelection_GroupRepo selectionGroupRepo, IApplicationTransaction_RequestRepo applicationTransactionRequestRepo,
                              ISlideShowRepo SlideshowRepo)
        {
            _logger = logger;
            this.db = db;
            this.userManager = userManager;
            this.homeRepo = homeRepo;
            this.requirementsRepo = requirementsRepo;
            this.transactionItemRepo = transactionItemRepo;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.requirmentsFileAttachmentRepo = requirmentsFileAttachmentRepo;
            _assignInquireytToItemRepo = assignInquireytToItemRepo;
            _transactionItemInquiryRepo = transactionItemInquiryRepo;
            _itemSelectionRepo = itemSelectionRepo;
            _assignSelectionToItemRepo = assignSelectionToItemRepo;
            _selectionGroupRepo = selectionGroupRepo;
            this.applicationTransactionRequestRepo = applicationTransactionRequestRepo;
            _slideshowRepo = SlideshowRepo;
        }
      
        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM()
            {
                TransactionSubGroupVM = homeRepo.GetAllTransactionSubGroups().Select(a => new TransactionSubGroupVM
                {
                    ID = a.ID,
                    SubGroupNameArabic = a.SubGroupNameArabic,
                    SubGroupNameEnglish = a.SubGroupNameEnglish,
                    



                }),

                TransactionGroupVM = homeRepo.GetAllTransactionGroup().Select(a => new TransactionGroupVM {
                    ID = a.ID,
                    TransactionGroup_NameArabic = a.TransactionGroup_NameArabic, 
                    TransactionGroup_NameEnglish = a.TransactionGroup_NameEnglish,
                    image = a.logo ,
                    count= transactionItemRepo.GetAll().Where(c=>c.TransactionGroupID == a.ID).Count()
                }),
                PopularTransactionItemVM= homeRepo.GetAllTransactionItem().Where(c=>c.SetInMostServices == true).Select(a => new TransactionItemVM { ID = a.ID, TransactionNameArabic = a.TransactionNameArabic, TransactionNameEnglish = a.TransactionNameEnglish, image = a.ServicesPhoto }),
                SlideShowVM = _slideshowRepo.GetAll().Select(a=> new SlideShowVM()
                {
                    ID = a.ID,
                    Title_Arabic = a.Title_Arabic,
                    ReSizeme_English = a.ReSizeme_English,
                    Title_English = a.Title_English,
                    ReSizeme_Arabic = a.ReSizeme_Arabic,
                    SlideImage = a.SlideImage
                })
            };

            return View(homeVM);
        }

        public IActionResult showSelectedSubGroup(int id)
        {


            HomeVM homeVM = new HomeVM()
            {
                TransactionSubGroupVM = homeRepo.GetAllTransactionSubGroups().Where(a => a.TransactionGroupID  == id).Select(a => new TransactionSubGroupVM
                {
                    ID = a.ID,
                    SubGroupNameArabic = a.SubGroupNameArabic,
                    SubGroupNameEnglish = a.SubGroupNameEnglish,
                    TransactionGroupID = a.TransactionGroupID,
                    //TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(x=>x.ID==id).Select(a=>a.TransactionGroup_NameEnglish).FirstOrDefault(),
                    count= transactionItemRepo.GetAll().Where(i => i.TransactionSubGroupID == a.ID).Count(),
                    


                }).ToList(),
                TransactionItemVM = transactionItemRepo.GetAll().Where(i => i.TransactionGroupID == id).Select(c => new TransactionItemVM
                {
                    ID = c.ID,
                    TransactionGroupID=transactionGroupRepo.GetAll().Where(g=>g.ID == id  ).Select(a=>a.ID ).FirstOrDefault (), 
                    TransactionSubGroupID= transactionSubGroupRepo.GetAll().Where(s => s.ID == c.TransactionSubGroupID).Select(a => a.ID).FirstOrDefault(),
                    TransactionSubGroupNameEnglish = transactionSubGroupRepo.GetAll().Where(s => s.ID == c.TransactionSubGroupID ).Select(a => a.SubGroupNameEnglish).FirstOrDefault(),                     
                    TransactionNameArabic = c.TransactionNameArabic,
                    TransactionGroupNameEnglis = c.TransactionNameEnglish,
                    Time_Services_Arabic = c.Time_Services_Arabic,
                    Time_Services_English = c.Time_Services_English,
                    TransactionNameEnglish = c.TransactionNameEnglish,
                    ServicesDecription_Arabic = c.ServicesDecription_Arabic,
                    ServicesDecription_English = c.ServicesDecription_English,
                    Price = c.Price,
                    GovernmentFees = c.GovernmentFees,
                    ServicesPhoto = c.ServicesPhoto,
                    Services_Conditions_Arabic = c.Services_Conditions_Arabic,
                    Services_Conditions_English = c.Services_Conditions_English
                    
                    

                }).ToList().OrderBy(o=>o.TransactionSubGroupID),

                PopularTransactionItemVM = homeRepo.GetAllTransactionItem().Where(c => c.SetInMostServices == true).Select(a => new TransactionItemVM { ID = a.ID, TransactionNameArabic = a.TransactionNameArabic, TransactionNameEnglish = a.TransactionNameEnglish, image = a.ServicesPhoto }),
                PopularTransactionItemVMINGroup= homeRepo.GetAllTransactionItem().Where(c => c.SetInMostServices_INSubGroup == true && c.TransactionGroupID==id).Select(a => new TransactionItemVM { ID = a.ID, TransactionNameArabic = a.TransactionNameArabic, TransactionNameEnglish = a.TransactionNameEnglish, image = a.ServicesPhoto })
            };
          



            return View(homeVM);
        }

        public IActionResult SelectFavoirotServives( int id)
        {
           
            var data = transactionItemRepo.GetAll().Where(c => c.ID == id).Select(a => new TransactionItemVM
            {

                ID = a.ID,
                TransactionNameArabic = a.TransactionNameArabic,
                TransactionNameEnglish = a.TransactionNameEnglish,
                ServicesDecription_Arabic = a.ServicesDecription_Arabic,
                ServicesDecription_English = a.ServicesDecription_English,
                Price = a.Price,
                GovernmentFees = a.GovernmentFees,
                Time_Services_Arabic = a.Time_Services_Arabic,
                Time_Services_English = a.Time_Services_English,
                ServicesPhoto = a.ServicesPhoto,
                TransactionGroupName = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID)
                    .Select(m => m.TransactionGroup_NameArabic).FirstOrDefault(),
                TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID)
                    .Select(m => m.TransactionGroup_NameEnglish).FirstOrDefault(),
                TransactionSubGroupName = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID)
                    .Select(x => x.SubGroupNameArabic).FirstOrDefault(),
                TransactionSubGroupNameEnglish = transactionSubGroupRepo.GetAll()
                    .Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameEnglish).FirstOrDefault(),
                Services_Conditions_English = a.Services_Conditions_English,
                Services_Conditions_Arabic = a.Services_Conditions_Arabic,
                AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(r => r.TransactionItemID == a.ID)
                    .Select(s => new AssignRequirmentToItemVM()
                    {
                        ID = s.ID,
                        Requirements_NameArabic = requirementsRepo.GetAll().Where(x => x.ID == s.RequirmentID)
                            .Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        Requirements_English = requirementsRepo.GetAll().Where(x => x.ID == s.RequirmentID)
                            .Select(a => a.RequirementName_English).FirstOrDefault(),
                    }).ToList(),

                RequirmentsFileAttachmentVM = assignRequirmentToItemRepo.GetAll()
                    .Where(r => r.TransactionItemID == a.ID).Select(c => new RequirmentsFileAttachmentVM()
                    {
                        RequireID = c.RequirmentID,
                        RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID)
                            .Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                        RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID)
                            .Select(a => a.RequirementName_English).FirstOrDefault(),
                        FileHistoryName = requirmentsFileAttachmentRepo.GetAll().Where(r=>r.RequireID==c.RequirmentID && r.UserID == User.FindFirstValue(ClaimTypes.NameIdentifier) && r.FileName!= null).Select(a=>
                            new RequirmentsFileAttachmentVM()
                            {
                                RequireID = a.RequireID,
                                FileName = a.FileName,
                                AppDateTime = applicationTransactionRequestRepo.GetAll().Where(t=>t.ID==a.App_Code).Select(a=>a.The_Date).FirstOrDefault(),
                                RequireName_Arabic = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID)
                                .Select(a => a.RequirementName_Arabic).FirstOrDefault(),
                                RequireName_English = requirementsRepo.GetAll().Where(x => x.ID == c.RequirmentID)
                                    .Select(a => a.RequirementName_English).FirstOrDefault(),

                            }

                           )
                        

                    }).ToList(),
                RequestInquiry_Answer_VM = _assignInquireytToItemRepo.GetAll().Where(n => n.TransactionItemID == a.ID)
                    .Select(m => new RequestInquiry_Answer_VM()
                    {

                        InquiryID = m.InquiryID,
                        InquiryName_Arabic = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == m.InquiryID)
                            .Select(c => c.InquiryName_Arabic).FirstOrDefault(),
                        InquiryName_English = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == m.InquiryID)
                            .Select(c => c.InquiryName_English).FirstOrDefault(),
                        Inquiry_Type = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == m.InquiryID)
                            .Select(c => c.Inquiry_Type).FirstOrDefault()
                    }).ToList(),
                RequestSelectionVM = _assignSelectionToItemRepo.GetAll().Where(n => n.TransactionItemID == a.ID).Select(
                    m => new RequestSelectionVM()
                    {

                        SelectionID = m.SelectionID,
                        SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                            .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                        SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                            .Select(c => c.SelectionName_English).FirstOrDefault(),
                        SelectionGroupID = (from i in _itemSelectionRepo.GetAll()
                            join g in _selectionGroupRepo.GetAll() on i.SelectionGroupID equals g.ID  select i.SelectionGroupID).FirstOrDefault(),
                        Selection_GroupName_English = (from i in _itemSelectionRepo.GetAll()
                            join g in _selectionGroupRepo.GetAll() on i.SelectionGroupID equals g.ID
                            select g.Selection_GroupName_English).FirstOrDefault(),
                        Selection_GroupName_Arab = (from i in _itemSelectionRepo.GetAll()
                            join g in _selectionGroupRepo.GetAll() on i.SelectionGroupID equals g.ID
                            select g.Selection_GroupName_Arab).FirstOrDefault()
                    }).ToList()

            }).OrderBy(a => a.ID).ToList();
     
            ViewBag.SelectEnglish = new SelectList(_assignSelectionToItemRepo.GetAll().Where(n => n.TransactionItemID == id).Select(
                m => new RequestSelectionVM()
                {

                    SelectionID = m.SelectionID,
                    SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                    SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID)
                        .Select(c => c.SelectionName_English).FirstOrDefault()
                }), "SelectionID", "SelectionName_English");

            return View(data);
          
        }

        [Produces("application/json")]
        [HttpGet("search")]
        [Route("/Home/search/{id}")]
        public Task<IActionResult> Search(int id) 
        {
            try
            {
                string mainservices = HttpContext.Request.Query["mainservices"].ToString();
                var postTitle = transactionSubGroupRepo.GetAll().Where(p => p.TransactionGroupID==id &&  p.SubGroupNameEnglish.Contains(mainservices))
                .Select(p => p.SubGroupNameEnglish).ToList();
                return Task.FromResult<IActionResult>(Ok(postTitle));
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest("Not found"));
            }
        }


        // [AllowAnonymous]
        // [HttpPost]
        //// [Route("Home/AutoCompleteSubServices")]
        // [Route("Home/Search")]
        //public JsonResult AutoCompleteSubServices(string prefix)
        //{

        //    var searchSubservices = (from Subservices in this.transactionSubGroupRepo.GetAll()
        //                     where Subservices.SubGroupNameEnglish.StartsWith(prefix == null ? "" : prefix)
        //                     select new
        //                     {
        //                         label = Subservices.ID,
        //                         val = Subservices.SubGroupNameEnglish
        //                     }).ToList();

        //    return Json(searchSubservices);
        //}
        public IActionResult showSelectedGroup(int id)
        {

            var data = homeRepo.GetAllTransactionsByGroup(id).Select(a => new TransactionItemVM
            {
                ID = a.ID,
                TransactionNameArabic = a.TransactionNameArabic,
                TransactionNameEnglish = a.TransactionNameEnglish,
                GovernmentFees = a.GovernmentFees,
                Price = a.Price,
                TransactionGroupName = transactionGroupRepo.GetNameById(a.TransactionGroupID)
            });





            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
