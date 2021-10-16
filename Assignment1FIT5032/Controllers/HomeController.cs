﻿using Assignment1FIT5032.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
 
namespace Assignment1FIT5032.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Email()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Email
        [HttpPost]
        //string txtTo, string txtSubjectTitle, string txtContents,
        public async Task<ActionResult> form1(string txtTo, string txtSubjectTitle, string txtContents, HttpPostedFileBase fileAttachment, bool bulkEmail)
        {

            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            if (bulkEmail)
            {
                _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var users = _userManager.Users;
               
                using (MailMessage mm = new MailMessage())
                {

                    foreach (var user in users)
                    {
                        mm.To.Add(user.Email);
                    }
                    mm.From = new MailAddress(smtpSection.From);
                    mm.Subject = txtSubjectTitle;
                    mm.Body = txtContents;
                    mm.IsBodyHtml = false;

                    
                    Attachment data = new Attachment(
                    fileAttachment.InputStream,
                    fileAttachment.FileName);

                    mm.Attachments.Add(data);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = smtpSection.Network.Host;
                    smtp.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    smtp.Credentials = networkCred;
                    smtp.Port = smtpSection.Network.Port;
                    smtp.Send(mm);

                }

            }
            else
            {
                using (MailMessage mm = new MailMessage(smtpSection.From, txtTo))
                {

                    mm.Subject = txtSubjectTitle;
                    mm.Body = txtContents;
                    mm.IsBodyHtml = false;

                    Attachment data = new Attachment(
                    fileAttachment.InputStream,
                    fileAttachment.FileName);

                    mm.Attachments.Add(data);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = smtpSection.Network.Host;
                    smtp.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    smtp.Credentials = networkCred;
                    smtp.Port = smtpSection.Network.Port;
                    smtp.Send(mm);

                }
            }

            return View("Email");
        }

    }
}