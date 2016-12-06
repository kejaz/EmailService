using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Mail;
using System.Configuration;
using System.Configuration;

/// <summary>
/// Summary description for EmailSend
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EmailSendService : System.Web.Services.WebService {

    public EmailSendService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}
    [WebMethod]
    public int EmailSend(string msg, string email, string pUserid, string pPassword)
    {
            try
            {
                string UserID = ConfigurationSettings.AppSettings["UserID"].ToString();
                string Password = ConfigurationSettings.AppSettings["Pass"].ToString();
                if (UserID == pUserid && Password == pPassword)
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["FromEmail"].ToString());
                    message.Subject = "Password Assistance";
                    message.To.Add(new MailAddress(email));
                    message.Bcc.Add(new MailAddress(ConfigurationSettings.AppSettings["BccEmail"].ToString()));
                    message.Body = msg;
                    message.IsBodyHtml = true;
                    SmtpClient emailClient = new SmtpClient(ConfigurationSettings.AppSettings["SMTP"].ToString());
                    emailClient.Send(message);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            { 
                return 0;
            }
     }
    
}
