using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Controllers
{
    public class AssignInquiryToItemController : Controller
    {
        public dbContainer Db { get; }
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;

        //   private readonly dbContainer db;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly IAssignInquireytToItemRepo assignInquireytToItemRepo;
        private readonly ITransactionItemInquiryReop _transactionItemInquiryRepo;

        public AssignInquiryToItemController(ITransactionItemRepo transactionItemRepo, ITransactionSubGroupRepo transactionSubGroupRepo, ITransactionGroupRepo transactionGroupRepo,
            dbContainer db, IAssignRequirmentToItemRepo assignRequirmentToItemRepo,
            IRequirementsRepo requirementsRepo,
            IAssignInquireytToItemRepo assignInquireytToItemRepo, ITransactionItemInquiryReop transactionItemInquiryRepo)
        {
          
            this.transactionItemRepo = transactionItemRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            Db = db;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.requirementsRepo = requirementsRepo;
            this.assignInquireytToItemRepo = assignInquireytToItemRepo;
            _transactionItemInquiryRepo = transactionItemInquiryRepo;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {



                TransactionItemInfoVM = transactionItemRepo.GetAll().Select(a => new TransactionItemInfoVM
                {
                    ID = a.ID,
                    TransactionNameArabic = a.TransactionNameArabic,
                    TransactionNameEnglish = a.TransactionNameEnglish,
                    GovernmentFees = a.GovernmentFees,
                    Price = a.Price,
                    TransactionGroupID = a.TransactionGroupID,
                    TransactionGroupName = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID).Select(m => m.TransactionGroup_NameArabic).FirstOrDefault(),
                    TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID).Select(m => m.TransactionGroup_NameEnglish).FirstOrDefault(),
                    TransactionSubGroupID = a.TransactionSubGroupID,
                    TransactionSubGroupName = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameArabic).FirstOrDefault(),
                    TransactionSubGroupNameEnglish = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameEnglish).FirstOrDefault(),
                    Groupimage = transactionGroupRepo.GetAll().Where(x => x.ID == a.TransactionGroupID).Select(a => a.logo).FirstOrDefault(),
                    AssignInquireytToItemVM = assignInquireytToItemRepo.GetAll().Where(n => n.TransactionItemID == a.ID).Select(m => new AssignInquireytToItemVM()
                    {

                        TransactionItemID = m.TransactionItemID,
                        InquiryName_Arabic = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == m.InquiryID).Select(c => c.InquiryName_Arabic).FirstOrDefault(),
                        InquiryName_English = _transactionItemInquiryRepo.GetAll().Where(s => s.ID == m.InquiryID).Select(c => c.InquiryName_English).FirstOrDefault()
                    }).ToList()
                }).OrderBy(a => a.ID).ToList(),


            };
            return View(homeVM);
        }

        public IActionResult AddAssignInquiryToItem(int? Id)
        {
            drpInquiry model = new drpInquiry(); List<int> subjectsIds = new List<int>();
            if (Id.HasValue)
            {
                //Get teacher 
                var teacher = Db.transactionItem.Include("ItemInquiry").FirstOrDefault(x => x.ID == Id.Value);
                //Get teacher subjects and add each subjectId into subjectsIds list
                teacher.ItemInquiry.ToList().ForEach(result => subjectsIds.Add(result.InquiryID));

                //bind model 
                model.drpInquirys = Db.TransactionItemInquiry.Select(x => new SelectListItem { Text = x.InquiryName_Arabic, Value = x.ID.ToString() }).ToList();
                model.Id = teacher.ID;
                model.Name = teacher.TransactionNameArabic;
                model.InquirysIds = subjectsIds.ToArray();
            }
            else
            {
                model = new drpInquiry();
                model.drpInquirys = Db.TransactionItemInquiry.Select(x => new SelectListItem { Text = x.InquiryName_Arabic, Value = x.ID.ToString() }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddAssignInquiryToItem(drpInquiry model)
        {
            TransactionItem teacher = new TransactionItem();
            List<AssignInquiryToItem> teacherSubjects = new List<AssignInquiryToItem>();


            if (model.Id > 0)
            {
                //first find teacher subjects list and then remove all from db   
                teacher = Db.transactionItem.Include("ItemInquiry").FirstOrDefault(x => x.ID == model.Id);
                teacher.ItemInquiry.ToList().ForEach(result => teacherSubjects.Add(result));
                Db.AssignInquiryToItem.RemoveRange(teacherSubjects);
                Db.SaveChanges();

                //Now update teacher details  
              //  teacher.TransactionNameArabic = model.Name;
                if (model.InquirysIds != null)
                {
                    teacherSubjects = new List<AssignInquiryToItem>();

                    foreach (var subjectid in model.InquirysIds)
                    {
                        teacherSubjects.Add(new AssignInquiryToItem { InquiryID = subjectid, TransactionItemID = model.Id });
                    }
                    teacher.ItemInquiry = teacherSubjects;
                }
                Db.SaveChanges();

            }
            else
            {
                //teacher.Name = model.Name;
                //teacher.DateTimeInLocalTime = DateTime.Now;
                //teacher.DateTimeInUtc = DateTime.UtcNow;
                //if (model.SubjectsIds.Length > 0)
                //{
                //    foreach (var subjectid in model.SubjectsIds)
                //    {
                //        teacherSubjects.Add(new TeacherSubjects { SubjectId = subjectid, TeacherId = model.Id });
                //    }
                //    teacher.TeacherSubjects = teacherSubjects;
                //}
                //db.Teacher.Add(teacher);
                //db.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
