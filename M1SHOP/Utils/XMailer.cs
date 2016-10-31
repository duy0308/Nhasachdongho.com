using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

public class XMailer
{
    static String From = "songlong2k@gmail.com";

    public static void Send(String To, String Subject, String Body)
    {
        var mail = new MailMessage();
        mail.From = new MailAddress(From, From);
        mail.To.Add(To);
        mail.ReplyToList.Add(mail.From);
        mail.Subject = Subject;
        mail.Body = Body;
        mail.IsBodyHtml = true;

        var smtp = new SmtpClient("smtp.gmail.com", 25)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential("kentphp2@gmail.com", "songlong")
        };
        smtp.Send(mail);
    }
}