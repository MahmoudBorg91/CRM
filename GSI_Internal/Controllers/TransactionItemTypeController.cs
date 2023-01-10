using System.Linq;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.TransactionItem_TypeRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class TransactionItemTypeController : Controller
    {
        private readonly ITransactionItem_TypeRepo _itemTypeRepo;
        private readonly IFileHandling _fileHandling;

        public TransactionItemTypeController(ITransactionItem_TypeRepo itemTypeRepo , IFileHandling fileHandling)
        {
            _itemTypeRepo = itemTypeRepo;
            _fileHandling = fileHandling;
        }
        public IActionResult Index()
        {
            var data = _itemTypeRepo.GetAll().Select(a => new TransactionItem_TypeVM
            {
                ID = a.ID,
                NameArabic = a.NameArabic,
                NameEnglish = a.NameEnglish,
                Icon = a.Icon
            }).ToList();
            return View();
        }
    }
}
