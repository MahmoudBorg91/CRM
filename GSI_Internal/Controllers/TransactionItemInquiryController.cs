using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace GSI_Internal.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TransactionItemInquiryController : Controller
    {
        private readonly ITransactionItemInquiryReop _transactionItemInquiryRepo;

        public TransactionItemInquiryController(ITransactionItemInquiryReop transactionItemInquiryRepo )
        {
            _transactionItemInquiryRepo = transactionItemInquiryRepo;
        }
        [Authorize(Permissions.SubServicesInquiry.View)]
        public IActionResult Index()
        {
            var data = _transactionItemInquiryRepo.GetAll().Select(a => new TransactionItemInquiryVM()
            {
                ID = a.ID,
                InquiryName_Arabic = a.InquiryName_Arabic,
                InquiryName_English = a.InquiryName_English,
                Inquiry_Type = a.Inquiry_Type

            });
            return View(data);
        }
        [Authorize(Permissions.SubServicesInquiry.Create)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.SubServicesInquiry.Create)]
        public IActionResult Create(TransactionItemInquiryVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionItemInquiry newobj = new TransactionItemInquiry();
                newobj.ID = obj.ID;
                newobj.InquiryName_Arabic = obj.InquiryName_Arabic;
                newobj.InquiryName_English = obj.InquiryName_English;
                newobj.Inquiry_Type = obj.Inquiry_Type;
                _transactionItemInquiryRepo.AddObj(newobj);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
           
        }
        [Authorize(Permissions.SubServicesInquiry.Edit)]
        public IActionResult Edit(int Id)
        {
            var data = _transactionItemInquiryRepo.GetByID(Id);
            TransactionItemInquiryVM obj = new TransactionItemInquiryVM();
            obj.ID = data.ID;
            obj.InquiryName_Arabic=data.InquiryName_Arabic;
            obj.InquiryName_English = data.InquiryName_English;
            obj.Inquiry_Type = data.Inquiry_Type;
            return View(obj);
        }
        [HttpPost]
        [Authorize(Permissions.SubServicesInquiry.Edit)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransactionItemInquiryVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionItemInquiry newobj = new TransactionItemInquiry();
                newobj.ID = obj.ID;
                newobj.InquiryName_Arabic = obj.InquiryName_Arabic;
                newobj.InquiryName_English = obj.InquiryName_English;
                newobj.Inquiry_Type=obj.Inquiry_Type;
                _transactionItemInquiryRepo.UpdateObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.SubServicesInquiry.Delete)]
        
        public IActionResult Delete(int Id)
        {
            var data = _transactionItemInquiryRepo.GetByID(Id);
            TransactionItemInquiryVM obj = new TransactionItemInquiryVM();
            obj.ID = data.ID;
            obj.InquiryName_Arabic = data.InquiryName_Arabic;
            obj.InquiryName_English = data.InquiryName_English;
            obj.Inquiry_Type=data.Inquiry_Type;

            return View(obj);

        }
       
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Permissions.SubServicesInquiry.Delete)]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var data = _transactionItemInquiryRepo.DeleteObj(id);
            return RedirectToAction("index");
        }

    }
}
