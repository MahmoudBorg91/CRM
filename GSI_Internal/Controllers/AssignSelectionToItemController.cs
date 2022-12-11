using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Controllers
{
    public class AssignSelectionToItemController : Controller
    {
        public dbContainer Db { get; }
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;

        //   private readonly dbContainer db;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly ITransiactionItem_SelectionRepo _itemSelectionRepo;
        private readonly IAssignSelectionToItemRepo _assignSelectionToItemRepo;

        public AssignSelectionToItemController(ITransactionItemRepo transactionItemRepo, ITransactionSubGroupRepo transactionSubGroupRepo, ITransactionGroupRepo transactionGroupRepo,
            dbContainer db, IAssignRequirmentToItemRepo assignRequirmentToItemRepo,
            IRequirementsRepo requirementsRepo, ITransiactionItem_SelectionRepo itemSelectionRepo, IAssignSelectionToItemRepo assignSelectionToItemRepo
          )
        {
            this.transactionItemRepo = transactionItemRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            Db = db;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.requirementsRepo = requirementsRepo;
            _itemSelectionRepo = itemSelectionRepo;
            _assignSelectionToItemRepo = assignSelectionToItemRepo;
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
                    AssignSelectionToItemVM = _assignSelectionToItemRepo.GetAll().Where(n => n.TransactionItemID == a.ID).Select(m => new AssignSelectionToItemVM()
                    {

                        TransactionItemID = m.TransactionItemID,
                        SelectionName_Arabic = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID).Select(c => c.SelectionName_Arabic).FirstOrDefault(),
                        SelectionName_English = _itemSelectionRepo.GetAll().Where(s => s.ID == m.SelectionID).Select(c => c.SelectionName_English).FirstOrDefault()
                    }).ToList()
                }).OrderBy(a => a.ID).ToList(),


            };
            return View(homeVM);
        }

        public IActionResult AddAssignSelectionToItem(int? Id)
        {
            drpSelection model = new drpSelection(); List<int> subjectsIds = new List<int>();
            if (Id.HasValue)
            {
                //Get teacher 
                var teacher = Db.transactionItem.Include("ItemSelection").FirstOrDefault(x => x.ID == Id.Value);
                //Get teacher subjects and add each subjectId into subjectsIds list
                teacher.ItemSelection.ToList().ForEach(result => subjectsIds.Add(result.SelectionID));

                //bind model 
                model.drpSelections = Db.TransiactionItem_Selection.Select(x => new SelectListItem { Text = x.SelectionName_Arabic, Value = x.ID.ToString() }).ToList();
                model.Id = teacher.ID;
                model.Name = teacher.TransactionNameArabic;
                model.SelectionIds = subjectsIds.ToArray();
            }
            else
            {
                model = new drpSelection();
                model.drpSelections = Db.TransiactionItem_Selection.Select(x => new SelectListItem { Text = x.SelectionName_Arabic, Value = x.ID.ToString() }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddAssignSelectionToItem(drpSelection model)
        {
            TransactionItem teacher = new TransactionItem();
            List<AssignSelectionToItem> teacherSubjects = new List<AssignSelectionToItem>();


            if (model.Id > 0)
            {
                //first find teacher subjects list and then remove all from db   
                teacher = Db.transactionItem.Include("ItemSelection").FirstOrDefault(x => x.ID == model.Id);
                teacher.ItemSelection.ToList().ForEach(result => teacherSubjects.Add(result));
                Db.AssignSelectionToItem.RemoveRange(teacherSubjects);
                Db.SaveChanges();

                //Now update teacher details  
                //  teacher.TransactionNameArabic = model.Name;
                if (model.SelectionIds != null)
                {
                    teacherSubjects = new List<AssignSelectionToItem>();

                    foreach (var subjectid in model.SelectionIds)
                    {
                        teacherSubjects.Add(new AssignSelectionToItem { SelectionID = subjectid, TransactionItemID = model.Id });
                    }
                    teacher.ItemSelection = teacherSubjects;
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
