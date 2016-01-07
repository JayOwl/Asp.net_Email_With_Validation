using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.BusinessLogic
{
    public class MailHelper{
        public const string SUCCESS 
        = "Success! Your email has been sent.  Please allow up to 48 hrs for a reply.";
        const string ERROR = "FAIL TO SEND MAIL";
        const string            TO = "joel.r.benoit@gmail.com"; // Specify where you want this email sent.
                                            // This value may/may not be constant.
                                            // To get started use one of your email 
                                            // addresses.
        public string EmailFromArvixe(Message message) {
            
            // Use credentials of the Mail account that you created with the steps above.
            const string FROM        = "joel@jamped.com"; 
            const string FROM_PWD    = "joejob08*";                
            const bool   USE_HTML    = true;

            // Get the mail server obtained in the steps described above.
            const string SMTP_SERVER = "143.95.249.35";
            try {
                MailMessage mailMsg  = new MailMessage(FROM, TO);
                mailMsg.Subject      = message.Subject;
                mailMsg.Body         = message.Body + "<br/>sent by: " + message.Sender;
                mailMsg.IsBodyHtml   = USE_HTML;

                SmtpClient smtp      = new SmtpClient();
                smtp.Port            = 25;
                smtp.Host            = SMTP_SERVER;
                smtp.Credentials     = new System.Net.NetworkCredential(FROM, FROM_PWD);
                smtp.Send(mailMsg);
            }
            catch (System.Exception) {
                return ERROR;
            }
            return SUCCESS;
        }
    }
}
