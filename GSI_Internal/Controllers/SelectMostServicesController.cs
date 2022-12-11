using GSI_Internal.Context;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.HomeRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;


namespace GSI_Internal.Controllers
{
    [AllowAnonymous]
    public class SelectMostServicesController : Controller
    {
        private readonly ITransactionItemRepo transactionItemRepo;

        public SelectMostServicesController(ITransactionItemRepo transactionItemRepo)
        {
            this.transactionItemRepo = transactionItemRepo;
        }
        public IActionResult Index(TransactionItemInfoVM data)
        {
            
            return View();
        }
    }
}
