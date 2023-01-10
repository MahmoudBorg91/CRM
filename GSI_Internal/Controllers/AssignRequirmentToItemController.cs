using GSI_Internal.Contants;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;

namespace GSI_Internal.Controllers
{
    public class AssignRequirmentToItemController : Controller
    {
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;

        //   private readonly dbContainer db;
        private readonly IAssignRequirmentToItemRepo assignRequirmentToItemRepo;
        private readonly IRequirementsRepo requirementsRepo;
        private readonly IAssignInquireytToItemRepo assignInquireytToItemRepo;
        public dbContainer Db { get; }
        public AssignRequirmentToItemController(ITransactionItemRepo transactionItemRepo, ITransactionSubGroupRepo transactionSubGroupRepo, ITransactionGroupRepo transactionGroupRepo,
            dbContainer db, IAssignRequirmentToItemRepo assignRequirmentToItemRepo, IRequirementsRepo requirementsRepo, IAssignInquireytToItemRepo assignInquireytToItemRepo)
        {
            this.transactionItemRepo = transactionItemRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            Db = db;
            this.assignRequirmentToItemRepo = assignRequirmentToItemRepo;
            this.requirementsRepo = requirementsRepo;
            this.assignInquireytToItemRepo = assignInquireytToItemRepo;
        }

        [Authorize(Permissions.AssignRequirmentToItem.View)]
       
        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM()
            {



                TransactionItemInfoVM = transactionItemRepo.GetAll().Select(a=> new TransactionItemInfoVM
                {
                   ID=a.ID,
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
                   AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(n=>n.TransactionItemID==a.ID) .Select(m => new AssignRequirmentToItemVM()
                   {

                        TransactionItemID = m.TransactionItemID,
                        Requirements_NameArabic = requirementsRepo.GetAll().Where(s => s.ID == m.RequirmentID).Select(c => c.RequirementName_Arabic).FirstOrDefault(),
                        Requirements_English = requirementsRepo.GetAll().Where(s => s.ID == m.RequirmentID).Select(c => c.RequirementName_English).FirstOrDefault()
                    }).ToList()
                }).OrderBy(a=>a.ID).ToList(),
               

            };





            //var data = transactionItemRepo.GetAll().Select(a => new TransactionItemInfoVM()
            //{
            //    ID = a.ID,
            //    TransactionNameArabic = a.TransactionNameArabic,
            //    TransactionNameEnglish = a.TransactionNameEnglish,
            //    GovernmentFees = a.GovernmentFees,
            //    Price = a.Price,
            //    TransactionGroupID=a.TransactionGroupID,
            //    TransactionGroupName = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID).Select(m => m.TransactionGroup_NameArabic).FirstOrDefault(),
            //    TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(g => g.ID == a.TransactionGroupID).Select(m => m.TransactionGroup_NameEnglish).FirstOrDefault(),
            //    TransactionSubGroupID =a.TransactionSubGroupID,
            //    TransactionSubGroupName = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameArabic).FirstOrDefault(),
            //    TransactionSubGroupNameEnglish = transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(x => x.SubGroupNameEnglish).FirstOrDefault(),
            //    Groupimage = transactionGroupRepo.GetAll().Where(x => x.ID == a.TransactionGroupID).Select(a => a.logo).FirstOrDefault(),
            //    AssignRequirmentToItemVM = assignRequirmentToItemRepo.GetAll().Where(x => x.TransactionItemID == a.ID).Select(m => new AssignRequirmentToItemVM()
            //    {
            //        Requirements_NameArabic = requirementsRepo.GetAll().Where(s => s.ID == m.RequirmentID).Select(c => c.RequirementName_Arabic).FirstOrDefault(),
            //        Requirements_English = requirementsRepo.GetAll().Where(s => s.ID == m.RequirmentID).Select(c => c.RequirementName_English).FirstOrDefault()
            //    }).ToList()


            //}).ToList();
            return View(homeVM);
        }
        [Authorize(Permissions.AssignRequirmentToItem.Create)]
        
        public IActionResult Create()
        {
            ViewBag.SelectTransactionItem = transactionItemRepo.GetAll().Select(a => new { a.ID, a.TransactionNameArabic }).ToList();
            ViewBag.Selectrequirements = requirementsRepo.GetAll().Select(a => new { a.ID, a.RequirementName_Arabic }).ToList();
            return View();
        }

       
        [HttpPost]
        [Authorize(Permissions.AssignRequirmentToItem.Create)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssignRequirmentToItemVM obj)
        {


            if (ModelState.IsValid)
            {
                AssignRequirmentToItem newobj = new AssignRequirmentToItem();
                newobj.ID = obj.ID;
                newobj.TransactionItemID = obj.TransactionItemID;
                newobj.RequirmentID = obj.RequirmentID;

                assignRequirmentToItemRepo.AddObj(newobj);
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.AssignRequirmentToItem.Edit)]
      
        public IActionResult Edit(int Id)
        {
            ViewBag.SelectTransactionItem = transactionItemRepo.GetAll().ToList();
            ViewBag.Selectrequirements = requirementsRepo.GetAll().ToList();

            var data = assignRequirmentToItemRepo.GetById(Id);
            AssignRequirmentToItemVM obj = new AssignRequirmentToItemVM();
            obj.ID = data.ID;
            obj.RequirmentID = data.RequirmentID;
            obj.TransactionItemID = data.TransactionItemID;
            return View(obj);
        }
        [HttpPost]
        [Authorize(Permissions.AssignRequirmentToItem.Edit)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AssignRequirmentToItemVM obj)
        {
            if (ModelState.IsValid)
            {
                AssignRequirmentToItem EditObj = new AssignRequirmentToItem();
                EditObj.ID = obj.ID;
                EditObj.RequirmentID = obj.RequirmentID;
                EditObj.TransactionItemID = obj.TransactionItemID;
                assignRequirmentToItemRepo.UpdateObj(EditObj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.AssignRequirmentToItem.Delete)]
    
        public IActionResult Delete(int Id)
        {
            ViewBag.SelectTransactionItem = transactionItemRepo.GetAll().ToList();
            ViewBag.Selectrequirements = requirementsRepo.GetAll().ToList();
            var data = assignRequirmentToItemRepo.GetById(Id);
            AssignRequirmentToItemVM obj = new AssignRequirmentToItemVM();
            obj.ID = data.ID;
            obj.RequirmentID = data.RequirmentID;
            obj.TransactionItemID = data.TransactionItemID;

            return View(obj);

        }
        [Authorize(Permissions.AssignRequirmentToItem.Delete)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var data = assignRequirmentToItemRepo.DeleteObj(id);
            return RedirectToAction("index");
        }




        [Authorize(Permissions.AssignRequirmentToItem.View)]
        [Authorize(Permissions.AssignRequirmentToItem.Create)]
        [Authorize(Permissions.AssignRequirmentToItem.Edit)]
        
        public IActionResult AddAssignRequirToItem(int? Id)
        {
            drpRequirmemt model = new drpRequirmemt(); List<int> subjectsIds = new List<int>();
            if (Id.HasValue)
            {
                //Get teacher 
                var teacher = Db.transactionItem.Include("ItemRequirs").FirstOrDefault(x => x.ID == Id.Value);
                //Get teacher subjects and add each subjectId into subjectsIds list
                teacher.AssignRequirmentToItems.ToList().ForEach(result => subjectsIds.Add(result.RequirmentID));

                //bind model 
                model.drpRequirment = Db.Requirements.Select(x => new SelectListItem { Text = x.RequirementName_Arabic, Value = x.ID.ToString() }).ToList();
                model.Id = teacher.ID;
                model.Name = teacher.TransactionNameArabic;
                model.RequirmentsIds = subjectsIds.ToArray();
            }
            else
            {
                model = new drpRequirmemt();
                model.drpRequirment = Db.Requirements.Select(x => new SelectListItem { Text = x.RequirementName_Arabic, Value = x.ID.ToString() }).ToList();
            }

            return View(model);
        }


        [Authorize(Permissions.AssignRequirmentToItem.View)]
        [Authorize(Permissions.AssignRequirmentToItem.Create)]
        [Authorize(Permissions.AssignRequirmentToItem.Edit)]
        [HttpPost]
        public IActionResult AddAssignRequirToItem(drpRequirmemt model)
        {
            TransactionItem teacher = new TransactionItem();
            List<AssignRequirmentToItem> teacherSubjects = new List<AssignRequirmentToItem>();


            if (model.Id > 0)
            {
                //first find teacher subjects list and then remove all from db   
                teacher = Db.transactionItem.Include("ItemRequirs").FirstOrDefault(x => x.ID == model.Id);
                teacher.AssignRequirmentToItems.ToList().ForEach(result => teacherSubjects.Add(result));
                Db.AssignRequirmentToItem.RemoveRange(teacherSubjects);
                Db.SaveChanges();

                //Now update teacher details  
                //teacher.TransactionNameArabic = model.Name;
                if (model.RequirmentsIds != null)
                {
                    teacherSubjects = new List<AssignRequirmentToItem>();

                    foreach (var subjectid in model.RequirmentsIds)
                    {
                        teacherSubjects.Add(new AssignRequirmentToItem { RequirmentID = subjectid, TransactionItemID = model.Id });
                    }
                    teacher.AssignRequirmentToItems = teacherSubjects;
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
