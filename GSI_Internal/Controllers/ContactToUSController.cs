using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GSI_Internal.EmailServices;
using GSI_Internal.Models.EmailViewModel;
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;
using AutoMapper;
using GSI_Internal.Repositry.ContactUsRepo;
using GSI_Internal.Models;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ContactToUSController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IContatUsRepo _contatUsRepo;
        private readonly IMapper _mapper;

        public ContactToUSController(IEmailSender emailSender, IContatUsRepo contatUsRepo, IMapper mapper)
        {
            _emailSender = emailSender;
            _contatUsRepo = contatUsRepo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _contatUsRepo.GetAll().FirstOrDefault();
            var map = _mapper.Map<ContactUsVM>(data);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> SentMail(MailContactUs_Vm obj)
        {

            var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[firstname]", obj.FirstName).Replace("[lastname]", obj.LastName).Replace("[phone]", obj.Phone).Replace("[email]", obj.Email).Replace("[note]", obj.Note);

            await _emailSender.SendEmailAsync("info@nebuae.com", obj.Subject, mailText);

        

            return RedirectToAction("Index");
        }
    }
}
