using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Home/
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Message msg)
        {
            MailHelper mailer = new MailHelper();
            string response = mailer.EmailFromArvixe(
                                       new Message(msg.Sender, msg.Subject, msg.Body));
            if (response == "FAIL TO SEND MAIL")
            {
                ViewBag.Response = response;
                return View();
            }
            else
            {
                return RedirectToAction("Success", new { message = response }); 
            }       
        }

        public ActionResult Success(string message) {
            ViewBag.Response = message;
            return View();            
        }


	}
}