using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Repositories;
using AircraftReport.Models;
using System.Net.Mail;
using System.Net;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AircraftReport.Services
{
    public class EmailSender
    {
        public bool SendEmail(string textEurope, string textNOTEurope)
        {
            File.WriteAllText("Report_ArrivingEuropeanAircrafts.html", textEurope);
            //Second table start*****************
            File.WriteAllText("Report_ArrivingNOTEuropeanAircrafts.html", textNOTEurope);
            //Second table end*******************
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(File.ReadAllText("C:\\txtSmtp.txt"));
            mail.From = new MailAddress("Petras@technas.lt");
            mail.To.Add("fizfakas@gmail.com");
            mail.Subject = "Arriving aircrafts";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Body =
                "To whom it may concern,\n\n" +
                "Two HTML-formated reports are enclosed to this letter.\n\n" +
                "Best regards,\n" +
                "Petras Petraitis,\n" +
                "Chief Security Officer";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            Attachment attachmentEurope;
            attachmentEurope = new Attachment("Report_ArrivingEuropeanAircrafts.html");
            mail.Attachments.Add(attachmentEurope);
            //Second table start*****************
            Attachment attachmentNOTEurope;
            attachmentNOTEurope = new Attachment("Report_ArrivingNOTEuropeanAircrafts.html");
            mail.Attachments.Add(attachmentNOTEurope);
            //Second table end*******************
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential
                (File.ReadAllText("C:\\txtAcc.txt"), File.ReadAllText("C:\\txtPass.txt"));
            SmtpServer.EnableSsl = false;

            try
            {
                SmtpServer.Send(mail);
                Console.WriteLine("Email was sent");
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
