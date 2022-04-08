using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjektsLiene.Models;
using System.Diagnostics;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System;

namespace ProjektsLiene.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Koucings()
        {
            return View();
        }

        public IActionResult Masaza()
        {
            return View();
        }

        public IActionResult Joga()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Kontakti()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kontakti(SendMailToModel sendMailTo)
        {
            if (!ModelState.IsValid) return View();
            TempData["AlertMessage"] = "Ziņa nosūtīta!";
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("Kontaktforma@mindfulliene.com", "MindfulLiene");

                mail.To.Add("maksims.bogdanovs@gmail.com");

                mail.Subject = sendMailTo.Subject;

                mail.IsBodyHtml = true;

                string content = "Vārds : " + sendMailTo.Name;
                content += "<br/> Ziņa : " + sendMailTo.Message;
                content += "<br/> Kontakttālrunis : " + sendMailTo.Phone;

                mail.Body = content;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                NetworkCredential networkCredential = new NetworkCredential("maksims.bogdanovs@gmail.com", "plshozmuocoavkrb");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ModelState.Clear();

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message.ToString();
            }

            return View();
        }


        [HttpPost]
        public IActionResult Index(SendSubscribers sendSubscribers)
        {
            if (!ModelState.IsValid) return View();
            TempData["AlertMessage"] = "Jūs esat veiksmīgi pierakstījušies jaunumiem";
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("Kontaktforma@mindfulliene.com", "MindfulLiene");

                mail.To.Add("maksims.bogdanovs@gmail.com");

                mail.Subject = "Jauns pieraksts jaunumu saņemšanai";

                mail.IsBodyHtml = true;

                string content = "Epats: " + sendSubscribers.Email;
                content += "<br/> Šis cilvēks grib pievienoties jaunumu saņemšanai";
                

                mail.Body = content;


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                NetworkCredential networkCredential = new NetworkCredential("maksims.bogdanovs@gmail.com", "plshozmuocoavkrb");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ModelState.Clear();

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message.ToString();
            }
            return View();
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
